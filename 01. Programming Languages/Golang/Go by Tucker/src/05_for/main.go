package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	stdio := bufio.NewReader(os.Stdin)
	for {
		fmt.Println("Input Number !!")
		var number int
		_, err := fmt.Scanln(&number)

		if err != nil {
			fmt.Println("Again input number !")
			stdio.ReadString('\n') // 버터 클리어
			continue
		}
		fmt.Printf("Input number is %d\n", number)
		if number%2 == 0 {
			break
		}
	}

	a := 1
	b := 1

OuterFor: // label을 사용한 break.. 이 레이블 아래의 for문을 탈출하게 된다.
	for ; a <= 9; a++ {
		for b = 1; b <= 9; b++ {
			if a*b == 56 {
				break OuterFor
			}
		}
	}
	fmt.Printf(" %d * %d = %d\n", a, b, a*b)

}
