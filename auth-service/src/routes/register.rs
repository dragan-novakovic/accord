use crate::{
    models::{errors::RegisterError, users::User},
    utils::builder_helper::res_builder,
};
use bson::Bson;
use bytes::Buf;
use hyper::{header, http, Body, Request, Response, StatusCode};
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

//! Use better pattern
pub async fn register(req: Request<Body>, db: Database) -> Result<Response<Body>, http::Error> {
    // Handle Error
    let whole_body = hyper::body::aggregate(req)
        .await
        .expect("Error aggregating body");

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

    let response = Response::builder()
        .status(StatusCode::CREATED)
        .header(header::CONTENT_TYPE, "application/json")
        .header(header::LOCATION, "/login")
        .body(Body::from(serde_json::to_string(&new_user).unwrap()))?;

    Ok(response)
}
