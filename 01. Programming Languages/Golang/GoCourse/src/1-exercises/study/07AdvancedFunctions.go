package study

import "fmt"

func AdFunction() {

	result := aggregate(34, 56, 12, myMul)

	fmt.Printf("result: %v\n", result)

	result = aggregate(11, 111, 123, myAdd)

	fmt.Printf("result: %v\n", result)

	squareFunc := selfMath(myMul)
	doubleFunc := selfMath(myAdd)

	result = squareFunc(20)
	fmt.Printf("result: %v\n", result)

	result = doubleFunc(56)
	fmt.Printf("result: %v\n", result)

	sampleAgrregator := concatter()

	sampleAgrregator("My")
	sampleAgrregator("name")
	sampleAgrregator("is")
	sampleAgrregator("Mr.Mun.")
	sampleAgrregator("\nDo")
	sampleAgrregator("you")
	sampleAgrregator("have")
	sampleAgrregator("a")
	sampleAgrregator("question?")

	fmt.Println(sampleAgrregator("\n"))

	nums := []int{1, 2, 3, 4, 5, 6, 7, 8, 9}

	allNumsDouble := doMath(func(x int) int {
		return x + x
	}, nums) //여기에서는 무명함수를 사용하였음.

	fmt.Printf("allNumsDouble: %v\n", allNumsDouble)
}

func doMath(mathFunc func(int) int, nums []int) []int {
	for i, num := range nums {
		nums[i] = mathFunc(num)
	}
	return nums
}

func myAdd(x, y int) int {
	return x + y
}

func myMul(x, y int) int {
	return x * y
}

func aggregate(x, y, z int, arithmethic func(int, int) int) int {
	return arithmethic(arithmethic(x, y), z)
}

func selfMath(mathFunc func(int, int) int) func(int) int {
	return func(x int) int {
		return mathFunc(x, x)
	}
}

// defer 는 함수의 마지막에 호출한다.
// File Close 같은 함수를 호출하는 경우에 defer 키워드와 함께 사용하면 간편하게 사용할 수 있다.
// 굳이 예제는 만들지 않겠다. 단순함. 명료함.

// 아래는  Closures //잘쓰면 유용할듯하지만, 잘 쓰지 않는다고 함.
func concatter() func(string) string {
	doc := "" // 여기서 포인트는 이 변수가 계속 유지된다는 것... 이것이 포인트. 그리고 이 함수는 함수를 return 하고, 또 그 함수는 String을 return 한다는 것도 포인트
	return func(s string) string {
		doc += s + " "
		return doc
	}
}
