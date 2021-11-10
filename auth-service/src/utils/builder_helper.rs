use hyper::{Body, Response, StatusCode};

pub fn res_builder(status: StatusCode, body: String) -> Result<Response<Body>, hyper::http::Error> {
    Response::builder().status(status).body(Body::from(body))
}
