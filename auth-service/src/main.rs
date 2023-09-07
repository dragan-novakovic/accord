#[macro_use]
extern crate serde_derive;
use hyper::service::{make_service_fn, service_fn};
use hyper::Server;
use std::convert::Infallible;
use std::net::SocketAddr;
extern crate serde;
extern crate serde_json;

mod models;
mod routes;
mod utils;

use utils::context::Context;
use utils::database::Database;
use utils::logger::Logger;
use utils::settings::Settings;

#[tokio::main]
async fn main() {
    let settings = match Settings::new() {
        Ok(value) => value,
        Err(err) => panic!("Failed to setup configuration. Error: {}", err),
    };

    let addr = SocketAddr::from(([0, 0, 0, 0], settings.server.port));

    Logger::setup(&settings);

    let db = match Database::setup(&settings).await {
        Ok(value) => value,
        Err(_) => panic!("Failed to setup database connection"),
    };

    let _context = Context::new(settings.clone());

    let make_svc = make_service_fn(|_conn| {
        let db = db.clone();
        async {
            Ok::<_, Infallible>(service_fn(move |req| {
                routes::router::router(req, db.conn.to_owned())
            }))
        }
    });

    let server = Server::bind(&addr).serve(make_svc);

    if let Err(e) = server.await {
        eprintln!("server error: {}", e);
    }
}
