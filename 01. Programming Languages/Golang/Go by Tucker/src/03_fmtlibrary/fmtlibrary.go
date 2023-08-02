package main

import "fmt"

func main() {
	var a int = 10
	var b int = 20
	var f float32 = 3123.14123123
	var c = 123456789

	fmt.Print("a:", a, "b:", b, "f:", f, "\n")
	fmt.Println("a:", a, "b:", b, "f:", f)
	fmt.Printf("a: %d, b: %d, f: %.1f\n", a, b, f)
	fmt.Printf("a: %v, b: %v, f: %v\n", a, b, f)

	fmt.Printf("a: %5d, b: %5d, f: %.1f\n", a, b, f)
	fmt.Printf("a: %05d, b: %05d, f: %.1f\n", a, b, f)
	fmt.Printf("a: %-5d, b: %-05d, f: %.1f\n", a, b, f)

	fmt.Printf("c: %5d, c: %5d, f: %.1f\n", c, c, f)
	fmt.Printf("c: %05d, c: %05d, f: %.1f\n", c, c, f)
	fmt.Printf("c: %-5d, c: %-05d, f: %.1f\n", c, c, f)
}
