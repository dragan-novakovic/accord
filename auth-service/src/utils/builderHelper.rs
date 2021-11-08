use hyper::{header, http, Body, Request, Response, StatusCode};

pub fn ResBuilder(status: i32, body: String) -> Builder {
    Response::builder().status(status).body(body)
}
