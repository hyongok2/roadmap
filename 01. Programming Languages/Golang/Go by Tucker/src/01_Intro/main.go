package main

import (
	"fmt"
)

func main() {
	fmt.Println("hello go world!")
	var a int = 10
	var msg string = "hello"

	a = 20
	msg = "good morning"

	fmt.Println(msg, a)

	d := 12.2

	fmt.Println(d)

	var ff float64 = 3.14

	var ii int = int(ff)

	fmt.Println(ii)

}
