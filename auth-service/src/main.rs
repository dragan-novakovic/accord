#![deny(warnings)]
#[macro_use]
extern crate serde_derive;
use hyper::service::{make_service_fn, service_fn};
use hyper::Server;
use std::convert::Infallible;
use std::env;
use std::net::SocketAddr;
use tokio::net::TcpListener;
extern crate serde;
extern crate serde_json;

mod models;
mod routes;
mod utils;

use utils::context::Context;
use utils::database::Database;
use utils::logger::Logger;
use utils::settings::Settings;

use crate::utils::settings;

fn setup_enviroment() -> Settings {
    match Settings::new() {
        Ok(value) => value,
        Err(err) => panic!("Failed to setup configuration. Error: {}", err),
    }
}

fn setup_logger(settings: Settings) {
    Logger::setup(&settings);
}

fn setup_server(settings: Settings) -> TcpListener {
    let ip: (i32, i32, i32, i32) = settings
        .server
        .address
        .split(',')
        .map(|x| x.parse::<i32>().unwrap())
        .collect()
        .unwrap();

    let addr = SocketAddr::from((ip, settings.server.port));

    // Bind to the port and listen for incoming TCP connections
    TcpListener::bind(addr)
}

// An async function that consumes a request, does nothing with it and returns a
// response.
async fn hello(_: Request<hyper::body::Incoming>) -> Result<Response<Full<Bytes>>, Infallible> {
    Ok(Response::new(Full::new(Bytes::from("Hello World!"))))
}

#[tokio::main]
async fn main() -> Result<(), Box<dyn std::error::Error + Send + Sync>> {
    //setup env
    let settings = setup_enviroment();

    //setup logger
    setup_logger(settings);

    let db = match Database::setup(&settings).await {
        Ok(value) => value,
        Err(_) => panic!("Failed to setup database connection"),
    };

    let _context = Context::new(settings.clone());

    // let make_svc = make_service_fn(|_conn| {
    //     let db = db.clone();
    //     async {
    //         Ok::<_, Infallible>(service_fn(move |req| {
    //             routes::router::router(req, db.conn.to_owned())
    //         }))
    //     }
    // });

    let listener_promise = setup_server(settings);
    let listener = listener_promise.await?;

    loop {
        // When an incoming TCP connection is received grab a TCP stream for
        // client<->server communication.
        //
        // Note, this is a .await point, this loop will loop forever but is not a busy loop. The
        // .await point allows the Tokio runtime to pull the task off of the thread until the task
        // has work to do. In this case, a connection arrives on the port we are listening on and
        // the task is woken up, at which point the task is then put back on a thread, and is
        // driven forward by the runtime, eventually yielding a TCP stream.
        let (tcp, _) = listener.accept().await?;
        // Use an adapter to access something implementing `tokio::io` traits as if they implement
        // `hyper::rt` IO traits.
        let io = TokioIo::new(tcp);

        // Spin up a new task in Tokio so we can continue to listen for new TCP connection on the
        // current task without waiting for the processing of the HTTP1 connection we just received
        // to finish
        tokio::task::spawn(async move {
            // Handle the connection from the client using HTTP1 and pass any
            // HTTP requests received on that connection to the `hello` function
            if let Err(err) = http1::Builder::new()
                .serve_connection(io, service_fn(hello))
                .await
            {
                println!("Error serving connection: {:?}", err);
            }
        });
    }
}
