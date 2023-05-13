package main

import (
	"fmt"
	"log"
	"net/http"

	"github.com/hyongok2/dbapi/router"
)

func main() {
	fmt.Println("MongoDB API")
	fmt.Println("Server is Getting Started..")
	r := router.Router()
	log.Fatal(http.ListenAndServe(":4000", r))
	fmt.Println("Listening at port 4000...")
}
