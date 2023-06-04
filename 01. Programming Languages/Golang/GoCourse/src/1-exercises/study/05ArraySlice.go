package study

import "fmt"

type cost struct {
	day   int
	value float64
}

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

	fmt.Println(sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))

	names := []string{"조던", "우즈", "조코비치"}

	//printStrings(names) <- 이거 컴파일 에러
	printStrings(names...) //<- 이렇게 해야 함.

	costs := []cost{
		{0, 4.0},
		{1, 2.1},
		{1, 3.1},
		{5, 2.5},
		{5, 3.5},
		{6, 2.0},
	}
	fmt.Println(getCostByDay(costs))

	matrix := createMatrix(8, 8)

	for i := 0; i < len(matrix); i++ {
		fmt.Println(matrix[i])
	}

	fruits := []string{"사과", "바나나", "자두", "복숭아"}

	for index, value := range fruits {
		fmt.Println(index, value)
	}

}

func sum(nums ...int) int {
	num := 0
	for i := 0; i < len(nums); i++ {
		num += nums[i]
	}
	return num
}

func printStrings(strings ...string) {
	for i := 0; i < len(strings); i++ {
		fmt.Println(strings[i])
	}
}

func getCostByDay(costs []cost) []float64 {
	costByDay := []float64{}

	for i := 0; i < len(costs); i++ {
		day := costs[i].day
		value := costs[i].value

		for day >= len(costByDay) {
			costByDay = append(costByDay, 0.0)
		}
		costByDay[day] += value
	}

	return costByDay
}

func createMatrix(rows, cols int) [][]int {
	matrix := make([][]int, 0)

	for i := 0; i < rows; i++ {
		row := make([]int, 0)
		for j := 0; j < cols; j++ {
			row = append(row, i*j)
		}
		matrix = append(matrix, row)
	}
	return matrix
}
