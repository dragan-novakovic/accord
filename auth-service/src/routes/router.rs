use crate::{
    routes::{login::login, register::register},
    utils::{
        context::{full, BoxBody},
        errors::GenericError,
    },
};
use http::header;
use hyper::{body::Incoming, http, Method, Request, Response, StatusCode};

static NOTFOUND: &[u8] = b"Not Found";

// implement Outh google
// implement Oauth facebook
// implement Oauth Phone
// implement 0auth Microsoft
// implement 0auth Apple
// implement Windows hello ?
// pub async fn preflight(req: Request<Incoming>) -> Result<Response<BoxBody>, GenericError> {
//     let response = Response::builder()
//         .status(StatusCode::OK)
//         .header("Access-Control-Allow-Origin", "*")
//         .header("Access-Control-Allow-Headers", "*")
//         .header("Access-Control-Allow-Methods", "POST, GET, OPTIONS")
//         .body(Empty::<Bytes>::new().boxed())?;
//     Ok(response)
// }

pub async fn router(
    req: Request<Incoming>,
    db: mongodb::Database,
) -> Result<Response<BoxBody>, GenericError> {
    match (req.method(), req.uri().path()) {
        // (&Method::OPTIONS, "/") => preflight(req),
        (&Method::POST, "/register") => register(req, db).await,
        (&Method::POST, "/login") => login(req, db).await,
        (&Method::GET, "/status") => Ok(Response::builder()
            .status(StatusCode::OK)
            .header(header::CONTENT_TYPE, "application/json")
            .header(header::ACCESS_CONTROL_ALLOW_ORIGIN, "*")
            .header(header::ACCESS_CONTROL_ALLOW_HEADERS, "*")
            .body(full("{\"status\": \"OK\"}"))
            .unwrap()),
        _ => Ok(Response::builder()
            .status(StatusCode::NOT_FOUND)
            .body(full(NOTFOUND))
            .unwrap()),
    }
}

// async fn api_post_response(req: Request<IncomingBody>) -> Result<Response<BoxBody>> {
//     // Aggregate the body...
//     let whole_body = req.collect().await?.aggregate();
//     // Decode as JSON...
//     let mut data: serde_json::Value = serde_json::from_reader(whole_body.reader())?;
//     // Change the JSON...
//     data["test"] = serde_json::Value::from("test_value");
//     // And respond with the new JSON.
//     let json = serde_json::to_string(&data)?;
//     let response = Response::builder()
//         .status(StatusCode::OK)
//         .header(header::CONTENT_TYPE, "application/json")
//         .body(full(json))?;
//     Ok(response)
// }

// async fn api_get_response() -> Result<Response<BoxBody>> {
//     let data = vec!["foo", "bar"];
//     let res = match serde_json::to_string(&data) {
//         Ok(json) => Response::builder()
//             .header(header::CONTENT_TYPE, "application/json")
//             .body(full(json))
//             .unwrap(),
//         Err(_) => Response::builder()
//             .status(StatusCode::INTERNAL_SERVER_ERROR)
//             .body(full(INTERNAL_SERVER_ERROR))
//             .unwrap(),
//     };
//     Ok(res)
// }

// #[tokio::main]
// async fn main() -> Result<()> {
//     pretty_env_logger::init();

//     let addr: SocketAddr = "127.0.0.1:1337".parse().unwrap();

//     let listener = TcpListener::bind(&addr).await?;
//     println!("Listening on http://{}", addr);
//     loop {
//         let (stream, _) = listener.accept().await?;
//         let io = TokioIo::new(stream);

//         tokio::task::spawn(async move {
//             let service = service_fn(move |req| response_examples(req));

//             if let Err(err) = http1::Builder::new().serve_connection(io, service).await {
//                 println!("Failed to serve connection: {:?}", err);
//             }
//         });
//     }
// }
