package main

import "fmt"

func main() {

	fmt.Println("Welcome to pointers!!")

	var myvalue = 3

	var mypoint = &myvalue

	fmt.Println(mypoint)

	var pmy *int

	fmt.Println(pmy)

	*mypoint = 23

	fmt.Println(myvalue)

}
