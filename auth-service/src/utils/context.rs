use crate::utils::settings::Settings;

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
