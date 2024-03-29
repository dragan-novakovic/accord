use crate::{
    models::{
        shared::Claims,
        users::{InsertableUser, PublicUser, User},
    },
    utils::{
        context::{full, BoxBody},
        errors::GenericError,
    },
};
use bson::Bson;
use bytes::Buf;
use http_body_util::BodyExt;
use hyper::{body::Incoming as IncomingBody, header, Request, Response, StatusCode};
use jsonwebtoken::{encode, Algorithm, EncodingKey, Header};
use mongodb::{
    bson::{doc, from_bson},
    Database,
};

static AUTH_SECRET: &'static [u8] = b"some_secret_key";

pub async fn login(
    req: Request<IncomingBody>,
    db: Database,
) -> Result<Response<BoxBody>, GenericError> {
    let whole_body = req.collect().await?.aggregate();

    let data: InsertableUser = serde_json::from_reader(whole_body.reader()).unwrap();
    let users_collection = db.collection("users");

    // 1. look for profile
    let user_cursor = users_collection
        .find_one(Some(doc! {"username": data.username.unwrap()}), None)
        .await;

    let user_bson = match user_cursor {
        Ok(user) => user.unwrap(),
        Err(_) => Bson::Null,
    };

    // send failed

    let user: User = from_bson(user_bson).unwrap();

    // 2. check if passwords match
    if user.password == data.password {
        //3. give back jwt after register
        let my_claims = Claims {
            sub: "b@b.com".to_owned(),
            company: "ACME".to_owned(),
            exp: 10000000000,
        };

        let mut header = Header::default();
        header.kid = Some("signing_key".to_owned());
        header.alg = Algorithm::HS512;

        let token = match encode(&header, &my_claims, &EncodingKey::from_secret(AUTH_SECRET)) {
            Ok(t) => t,
            Err(_) => panic!(), // in practice you would return the error
        };

        let payload = user.remove_password().generate_token(token);
        let public_payload = PublicUser::from(payload.clone());

        let response = Response::builder()
            .status(StatusCode::OK)
            .header("Access-Control-Allow-Origin", "*")
            .header("Access-Control-Allow-Headers", "*")
            .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
            .header(header::CONTENT_TYPE, "application/json")
            .body(full(serde_json::to_string(&public_payload).unwrap()))?;
        return Ok(response);
    }

    let response = Response::builder()
        .status(StatusCode::UNAUTHORIZED)
        .header(header::CONTENT_TYPE, "application/json")
        .body(full("Wrong username or password"))?;
    Ok(response)
}
