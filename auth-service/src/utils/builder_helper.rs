use http::{header, Response};
use hyper::StatusCode;

use super::{
    context::{full, BoxBody},
    errors::GenericError,
};

pub fn res_builder(status: StatusCode, body: String) -> Result<Response<BoxBody>, GenericError> {
    let response = Response::builder()
        .status(status)
        .header(header::CONTENT_TYPE, "application/json")
        .header(header::ACCESS_CONTROL_ALLOW_ORIGIN, "*")
        .header(header::ACCESS_CONTROL_ALLOW_HEADERS, "*")
        .body(full(body))
        .unwrap();
    Ok(response)
}
