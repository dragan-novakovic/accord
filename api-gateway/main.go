package main

import (
	"net/http"

	"github.com/gorilla/mux"
)

var router = mux.NewRouter()

func main() {
	http.Handle("/", router)
	http.ListenAndServe(":80", router)
}
