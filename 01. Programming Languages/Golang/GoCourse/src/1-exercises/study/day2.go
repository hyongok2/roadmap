package study

import "fmt"

type things interface {
	getItemName() string
}

type computer struct {
	make  string
	model string
}

type car struct {
	make  string
	model string
}

func (c car) getItemName() string {
	return c.make + " " + c.model
}

func (c computer) getItemName() string {
	return c.make + " " + c.model
}

type truck struct {
	car     //embeded struct
	bedSize int
}

func (t truck) goForward() (message string) {
	return t.model + " Running~~~!"
}

func showName(t things) string {
	// c, ok := t.(car)

	// if ok {
	// 	return "Car " + c.getItemName()
	// }

	// c1, ok := t.(computer)

	// if ok {
	// 	return "Computer " + c1.getItemName()
	// }

	// return "No Item Name"

	switch v := t.(type) {
	case car:
		return "Car " + v.getItemName()
	case computer:
		return "Computer " + v.getItemName()
	default:
		return "No Item Name"
	}
}

func Day2() {
	valueA := 10
	valueB := 20

	valueA = add(valueA, valueB)

	changeValue(&valueA)

	fmt.Printf("valueA : %v\n", valueA)
	fmt.Printf("valueB : %v\n", valueB)

	myCar := truck{
		bedSize: 10,
	}

	myCar.make = "Tesla"
	myCar.model = "Cyber Truck"

	fmt.Printf("myCar : %v\n", myCar)

	yourCar := truck{
		bedSize: 20,
		car: car{
			make:  "Hyundai",
			model: "Poter",
		},
	}

	fmt.Printf("yourCar : %v\n", yourCar)

	fmt.Printf(yourCar.goForward() + "\n")

	fmt.Printf(showName(computer{
		make:  "samsung",
		model: "notebook",
	}) + "\n")

	fmt.Printf(showName(myCar) + "\n")

	newCar := car{
		make:  "Kia",
		model: "K5",
	}
	fmt.Printf(showName(newCar) + "\n")
}

func changeValue(valueA *int) {
	*valueA = 100
}

func add(valueA, valueB int) int {
	return valueA + valueB
}
