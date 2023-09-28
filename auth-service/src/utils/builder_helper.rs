use http::{header, Request, Response};
use hyper::{body::Incoming, StatusCode};

use super::{
    context::{full, BoxBody},
    errors::GenericError,
};

pub fn res_builder(status: StatusCode, body: String) -> Result<Response<BoxBody>, GenericError> {
    let response = Response::builder()
        .status(status)
        .header(header::CONTENT_TYPE, "application/json")
        .body(full(body))
        .unwrap();
    Ok(response)
}
