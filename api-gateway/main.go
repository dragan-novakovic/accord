package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"
	"time"

	"github.com/gorilla/mux"
)

var r = mux.NewRouter()

func main() {
	r.HandleFunc("/", HomeLander)

	r.HandleFunc("/api/health", func(w http.ResponseWriter, r *http.Request) {
		// an example API handler
		json.NewEncoder(w).Encode(map[string]bool{"ok": true})
	})

	var authRouter = r.PathPrefix("/auth").Subrouter()
	authRouter.HandleFunc("/{requestType}", authBeacon)
	http.Handle("/", r)

	var server = &http.Server{
		Handler: r,
		Addr:    "localhost:1111",
		// Good practice: enforce timeouts for servers you create!
		WriteTimeout: 15 * time.Second,
		ReadTimeout:  15 * time.Second,
	}

	log.Fatal(server.ListenAndServe())
}

func HomeLander(w http.ResponseWriter, r *http.Request) {
	w.WriteHeader(http.StatusTeapot)
}

func authBeacon(w http.ResponseWriter, r *http.Request) {
	var vars = mux.Vars(r)
	fmt.Fprintln(w, vars["requestType"])

	switch vars["requestType"] {
	case "Hi":
		fmt.Fprintln(w, "it is hi")
	}
}
