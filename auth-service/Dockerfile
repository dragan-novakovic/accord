FROM rust:1-slim-bullseye

WORKDIR /user/src/auth-service
COPY . .
RUN cargo build

EXPOSE 3000