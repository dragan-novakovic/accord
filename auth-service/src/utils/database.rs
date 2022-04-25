use mongodb::{options::ClientOptions, Client};

use crate::utils::settings::Settings;

#[derive(Clone)]
pub struct Database {
    pub conn: mongodb::Database,
}

impl Database {
    pub async fn setup(settings: &Settings) -> Result<Self, mongodb::error::Error> {
        // let connection = mongodb::Client::with_uri_str(db_uri)
        //     .await?
        //     .database(db_name);

        // Ok(Self { conn: connection })

        let client_options: ClientOptions = ClientOptions::parse(settings.database.uri.as_str())
            .await
            .expect("Error Parsing Database URI");

        // Get a handle to the deployment.
        let client = Client::with_options(client_options)
            .expect("Unable to create Deployment with specified Client Options");

        // Get a handle to a database.
        let db = client.database(settings.database.name.as_str());

        Ok(Self { conn: db })
    }
}
