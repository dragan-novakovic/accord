use hyper::{http, Body, Method, Request, Response, StatusCode};
use mongodb::Database;

use crate::routes::{login::login, register::register};

// implement Outh google
// implement Oauth facebook
// implement Oauth Phone
// implement 0auth Microsoft
// implement 0auth Apple
// implement Windows hello ?
pub async fn preflight(req: Request<Body>) -> Result<Response<Body>, http::Error> {
    let _whole_body = hyper::body::aggregate(req).await.unwrap();
    let response = Response::builder()
        .status(StatusCode::OK)
        .header("Access-Control-Allow-Origin", "*")
        .header("Access-Control-Allow-Headers", "*")
        .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
        .body(Body::default())?;
    Ok(response)
}

pub async fn router(req: Request<Body>, db: Database) -> Result<Response<Body>, http::Error> {
    match (req.method(), req.uri().path()) {
        (&Method::OPTIONS, "/") => preflight(req).await,
        (&Method::POST, "/register") => register(req, db).await,
        (&Method::POST, "/login") => login(req, db).await,
        (&Method::GET, "/status") => Response::builder()
            .status(200)
            .header("Content-Type", "aplication/json")
            .header("Access-Control-Allow-Origin", "*")
            .header("Access-Control-Allow-Headers", "*")
            .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
            .body(Body::from("{\"status\": \"OK\"}")),
        _ => Response::builder()
            .status(404)
            .header("Access-Control-Allow-Origin", "*")
            .header("Access-Control-Allow-Headers", "*")
            .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
            .body(Body::from("Not Found")),
    }
}
