use hyper::{http, Body, Response, StatusCode};

pub fn ResBuilder(status: StatusCode, body: String) -> Result<Response<Body>, http: Error> {
    Response::builder().status(status).body(Body::from(body))
}
