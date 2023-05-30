package study

import (
	"fmt"
)

func Day4() {
	result := maxMessages(100)
	fmt.Printf("%v\n", result)
	printPrimeNumber(20)
}

func maxMessages(thresh float64) int {

	totalcost := 0.0

	for i := 0; ; i++ {
		totalcost += 1.0 + (0.1 * float64(i))
		if totalcost > thresh {
			return i
		}
	}

	//Go don't have while loop.. instead 'for' do every thing.
}

func printEvenNumber(value int) {
	for i := 0; i < value; i++ {
		if i%2 != 0 {
			continue
		}
		fmt.Printf("%v\n", i)
	}
}

func printPrimeNumber(max int) {
	for n := 2; n < max; n++ {

		if n == 2 {
			fmt.Println(n)
			continue
		}

		if n%2 == 0 {
			continue
		}

		isPrime := true

		for i := 3; i*i < n+1; i++ {
			if n%i == 0 {
				isPrime = false
				continue
			}
		}

		if isPrime {
			fmt.Println(n)
		}

	}
}
