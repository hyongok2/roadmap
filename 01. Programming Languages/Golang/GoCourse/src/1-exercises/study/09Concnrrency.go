package study

import (
	"fmt"
	"sync"
	"time"
)

func square(wg *sync.WaitGroup, ch chan int) {
	for n := range ch {
		fmt.Printf("Square: %d\n", n*n)
		time.Sleep(time.Second)
	}
	wg.Done()
}

func Concurrency() {

	//go crunTest()
	//runTest()

	var wg sync.WaitGroup
	ch := make(chan int)

	wg.Add(1)
	go square(&wg, ch)

	for i := 0; i < 10; i++ {
		ch <- i * 2
	}
	close(ch)
	wg.Wait()

	isOldChan := make(chan bool)

	go sendIsOld(isOldChan)

	isOld := <-isOldChan
	fmt.Println("email 1 is old:", isOld)

	test(3)
	test(4)
	test(5)

	testfibo(10)
	testfibo(14)

}

func sendIsOld(isOldChan chan<- bool) {
	isOldChan <- false
}

func runTest() {

	for i := 0; i < 10; i++ {
		time.Sleep(time.Second * 1)
		fmt.Printf("Normal i: %v\n", i)
	}

}

func crunTest() {
	for i := 0; i < 10; i++ {
		time.Sleep(time.Second * 1)
		fmt.Printf("Concurrency i: %v\n", i)
	}

}

func waitForDbs(numDBs int, dbChan chan struct{}) {
	for i := 0; i < numDBs; i++ {
		<-dbChan // 소모를 해야 진행된다.
	}
}

func test(numDBs int) {
	dbChan := getDatabasesChannel(numDBs)
	fmt.Printf("Waiting for %v databases...\n", numDBs)
	waitForDbs(numDBs, dbChan)
	time.Sleep(time.Millisecond * 10) // ensure the last print statement happens
	fmt.Println("All databases are online!")
	fmt.Println("=====================================")
}

func getDatabasesChannel(numDBs int) chan struct{} {
	ch := make(chan struct{})
	go func() {
		for i := 0; i < numDBs; i++ {
			ch <- struct{}{}
			fmt.Printf("Database %v is online\n", i+1)
		}
	}()
	return ch
}

func concurrrentFib(n int) {

	ch := make(chan int)

	go fibonacci(n, ch)

	for v := range ch {
		fmt.Printf("v: %v\n", v)
	}

}

// don't touch below this line

func testfibo(n int) {
	fmt.Printf("Printing %v numbers...\n", n)
	concurrrentFib(n)
	fmt.Println("==============================")
}

func fibonacci(n int, ch chan int) {
	x, y := 0, 1
	for i := 0; i < n; i++ {
		ch <- x
		x, y = y, x+y
		time.Sleep(time.Millisecond * 10)
	}
	close(ch)
}
