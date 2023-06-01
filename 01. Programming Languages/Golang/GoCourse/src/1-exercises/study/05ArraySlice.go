package study

import "fmt"

func ArraySlice() {

	myArray := [3]int{1, 2, 3}

	fmt.Printf("myArray: %v\n", myArray)

	mySlice := myArray[:]
	mySlice = append(mySlice, myArray[0], 1, 2, 3, 4, 5)
	mySlice = append(mySlice, myArray[0:3]...)

	fmt.Printf("mySlice: %v\n", mySlice)

	makeSlice := make([]string, 10, 20) //생성

	for i := 0; i < len(makeSlice); i++ {
		makeSlice[i] = fmt.Sprintf("%v", i)
	}

	makeSlice = append(makeSlice, "Red")
	makeSlice = append(makeSlice, "Blue")
	makeSlice = append(makeSlice, "Green")

	fmt.Printf("makeSlice: %v\n", makeSlice)
	fmt.Println(cap(makeSlice))
	fmt.Println(cap(mySlice))

}
