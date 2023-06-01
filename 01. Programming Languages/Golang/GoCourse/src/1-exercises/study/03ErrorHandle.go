package study

import (
	"errors"
	"fmt"
	"strconv"
)

func ErrorHandle() {

	user, err := getUser()

	if err != nil {
		fmt.Println(err)
	}

	fmt.Println(user)

	i, err := strconv.Atoi("5r")

	if err != nil {
		fmt.Println(err)
	}

	fmt.Printf("value : %v \n", i)

	val, err := divide(34.123, 0)

	if err != nil {
		fmt.Println(err)
	}

	fmt.Printf("Result : %v \n", val)

}

func getUser() (user string, e error) {

	return "사람", errors.New("이것은 에러")
}

type divideError struct {
	dividend float64
}

func (d divideError) Error() string {
	return fmt.Sprintf("Can not divide %v By Zero", d.dividend)
}

func divide(dividend, divisor float64) (float64, error) {

	if divisor == 0 {
		return 0.0, divideError{dividend}
	}

	return dividend / divisor, nil
}
