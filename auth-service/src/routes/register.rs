use crate::{
    models::users::{PublicUser, User},
    utils::{
        builder_helper::res_builder,
        context::{full, BoxBody},
        errors::GenericError,
    },
};
use bson::Bson;
use bytes::Buf;
use http_body_util::BodyExt;
use hyper::{body::Incoming as IncomingBody, header, Request, Response, StatusCode};
use mongodb::{
    bson::{doc, from_bson},
    Database,
};

/*
{
 "username": String
 "password": String
}
 */

/// Use better pattern
pub async fn register(
    req: Request<IncomingBody>,
    db: Database,
) -> Result<Response<BoxBody>, GenericError> {
    // Handle Error
    let whole_body = req.collect().await?.aggregate();

    let data: serde_json::Value =
        serde_json::from_reader(whole_body.reader()).expect("Failed parsing the body");
    let users_collection = db.collection("users");

    let new_user_id = match bson::to_bson(&data) {
        Ok(result) => match result {
            Bson::Document(user_doc) => match users_collection.insert_one(user_doc, None).await {
                Ok(result) => Some(result.inserted_id.as_object_id().unwrap().clone()),
                Err(err) => {
                    eprintln!("Error {:?}", err);
                    return res_builder(StatusCode::SERVICE_UNAVAILABLE, "DbError".to_owned());
                }
            },
            _ => None,
        },
        Err(err) => {
            eprintln!("Error convectiong to bson {:?}", err);
            None
        }
    };

    // Handle Errors reading from DB
    let new_user_cursor: Bson = users_collection
        .find_one(Some(doc! {"_id": new_user_id.unwrap()}), None)
        .await
        .unwrap()
        .unwrap()
        .into();

    let new_user: User = from_bson(new_user_cursor).expect("Unable to parse from BSON");
    let public_payload = PublicUser::from(new_user.clone());

    let response = Response::builder()
        .status(StatusCode::CREATED)
        .header(header::CONTENT_TYPE, "application/json")
        .header("Access-Control-Allow-Origin", "*")
        .header("Access-Control-Allow-Headers", "*")
        .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
        .header(header::LOCATION, "/login")
        .body(full(serde_json::to_string(&public_payload).unwrap()))?;

    Ok(response)
}
