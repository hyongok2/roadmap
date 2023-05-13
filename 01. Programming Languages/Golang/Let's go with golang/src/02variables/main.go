package main

import "fmt"

func main() {
	var username string = "moon"
	fmt.Println(username)
	fmt.Printf("Variable is of type : %T \n", username)

	var isLoggedIn bool = true
	fmt.Println(isLoggedIn)
	fmt.Printf("Variable is of type : %T \n", isLoggedIn)

	var count = 3.14
	fmt.Println(count)
	fmt.Printf("Variable is of type : %T \n", count)

	var anothervalue int
	fmt.Println(anothervalue)
	fmt.Printf("Variable is of type : %T \n", anothervalue)

	var site = "yourSite"
	fmt.Printf(site)
}
