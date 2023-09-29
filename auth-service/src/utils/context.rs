//use super::errors::GenericError;
use crate::utils::settings::Settings;
use crate::Bytes;

use http_body_util::{BodyExt, Full};

#[derive(Clone)]
pub struct Context {
    // pub models: Models,
    pub settings: Settings,
}

impl Context {
    pub fn new(settings: Settings) -> Self {
        Self { settings }
    }
}

//pub type Result<T> = std::result::Result<T, GenericError>;
pub type BoxBody = http_body_util::combinators::BoxBody<Bytes, hyper::Error>;

pub fn full<T: Into<Bytes>>(chunk: T) -> BoxBody {
    Full::new(chunk.into())
        .map_err(|never| match never {})
        .boxed()
}
