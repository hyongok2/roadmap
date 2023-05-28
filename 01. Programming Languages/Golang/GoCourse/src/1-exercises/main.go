package main

import (
	"fmt"
)

func main() {
	fmt.Println("Les't Start Go Programming. Today is 2023.05.24")

	day1()
	day2()
}

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

func day2() {
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

func day1() {

	var smsSendingLimit int
	var cost float64
	var hasIt bool
	var username string
	fmt.Printf(
		"%v %f %v %q \n",
		smsSendingLimit, cost, hasIt, username)

	//empty := ""
	//numberCars := 20
	temperature := 34
	// var isFunny = true
	temperatureFloat := float64(temperature)
	fmt.Printf("numberCars TYPE : %T %v", temperatureFloat, temperatureFloat)

	messageLen := 100
	maxMessageLen := 200
	fmt.Println("Trying to send a message of length:", messageLen)

	if messageLen <= maxMessageLen {
		fmt.Println("Message sent")
	} else {
		fmt.Println("Message not sent")
	}

}
