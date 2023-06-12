package study

import "fmt"

func Pointers() {
	x := 5
	y := x
	z := &x

	fmt.Printf("x: %v\n", x)
	fmt.Printf("x: %v\n", &x)

	fmt.Printf("y: %v\n", &y)
	fmt.Printf("z: %v\n", z)

	myString := "hello"
	myStringPointer := &myString

	fmt.Printf("myStringPointer: %v\n", myStringPointer)

	a := 50
	b := &a
	*b = 100

	fmt.Printf("a: %v\n", a)

	scar := superCar{
		color: "white",
	}

	scar.setColor("yellow") // 이 함수에서는 기대했던 값 변경이 일어나지 않는다. 아래 함수에서 차이 확인

	ncar := niceCar{
		color: "white",
	}

	ncar.setColor("yellow") // 이 함수에서는 변경이 잘 된다. 차이는 포인터로 정의한 것.

	fmt.Printf("scar: %v\n", scar)
	fmt.Printf("ncar: %v\n", ncar)
}

type superCar struct {
	color string
}

//이런 방식은 잘 쓰지 않는다.
func (c superCar) setColor(color string) {
	c.color = color
}

type niceCar struct {
	color string
}

// 아래와 같은 방식이 일반적이다.
func (c *niceCar) setColor(color string) {
	c.color = color
}
