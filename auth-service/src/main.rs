#[macro_use]
extern crate serde_derive;
use bytes::Bytes;
use http::Request;
use hyper::body::Incoming;
use hyper::server::conn::http1;
use hyper::service::service_fn;
use routes::router::router;
use std::net::{Ipv4Addr, SocketAddrV4};
use std::sync::Arc;
use tokio::net::TcpListener;
use utils::tokio_io::TokioIo;

extern crate serde;
extern crate serde_json;

mod models;
mod routes;
mod utils;

use utils::context::Context;
use utils::database::Database;
use utils::logger::Logger;
use utils::settings::Settings;

fn setup_enviroment() -> Settings {
    match Settings::new() {
        Ok(value) => value,
        Err(err) => panic!("Failed to setup configuration. Error: {}", err),
    }
}

fn setup_logger(settings: &Settings) {
    Logger::setup(&settings);
}

fn setup_server(settings: &Settings) -> SocketAddrV4 {
    let ip: (u8, u8, u8, u8) =
        settings
            .server
            .address
            .split(',')
            .enumerate()
            .fold((0, 0, 0, 0), |mut acc, (index, x)| {
                let x_string = x.parse::<i32>().unwrap().try_into().unwrap();
                match index {
                    0 => acc.0 = x_string,
                    1 => acc.1 = x_string,
                    2 => acc.2 = x_string,
                    3 => acc.3 = x_string,
                    _ => println!("Hello"),
                }
                acc
            });

    SocketAddrV4::new(Ipv4Addr::new(ip.0, ip.1, ip.2, ip.3), settings.server.port)

    // Bind to the port and listen for incoming TCP connections
}

// An async function that consumes a request, does nothing with it and returns a
// response.

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error + Send + Sync>> {
    //setup env
    let settings = setup_enviroment();

    //setup logger
    setup_logger(&settings);

    let db: Arc<Database> = match Database::setup(settings.clone()).await {
        Ok(value) => Arc::new(value),
        Err(_) => panic!("Failed to setup database connection"),
    };

    let _context = Context::new(settings.clone());
    let address = setup_server(&settings);
    let listener = TcpListener::bind(address).await?;

    loop {
        let db = Arc::clone(&db);
        // Note, this is a .await point, this loop will loop forever but is not a busy loop. The
        // .await point allows the Tokio runtime to pull the task off of the thread until the task
        // has work to do. In this case, a connection arrives on the port we are listening on and
        // the task is woken up, at which point the task is then put back on a thread, and is
        // driven forward by the runtime, eventually yielding a TCP stream.
        let (tcp, _) = listener.accept().await?;
        let io = TokioIo::new(tcp);
        let service = service_fn(move |req: Request<Incoming>| router(req, db.conn.to_owned()));
        // Spin up a new task in Tokio so we can continue to listen for new TCP connection on the
        // current task without waiting for the processing of the HTTP1 connection we just received
        // to finish
        tokio::task::spawn(async move {
            if let Err(err) = http1::Builder::new().serve_connection(io, service).await {
                println!("Error serving connection: {:?}", err);
            }
        });
    }
}
