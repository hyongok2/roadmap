package study

import "fmt"

func Variables() {

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
