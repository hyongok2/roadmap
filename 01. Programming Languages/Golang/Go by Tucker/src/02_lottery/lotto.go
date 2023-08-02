package main

import (
	"bufio"
	"fmt"
	"math/rand"
	"os"
	"strconv"
	"time"
)

// 추첨을 통해 책을 주는 프로그램
func main() {
	// lottery.exe filename count
	if len(os.Args) < 3 {
		fmt.Fprintln(os.Stderr, "Invalid argument!")
	}
	filename := os.Args[1]
	count, err := strconv.Atoi(os.Args[2])
	if err != nil {
		fmt.Fprintln(os.Stderr, "Cannot Convert to Int! count:", count)
	}

	candidates, err := readCandidates(filename)
	if err != nil {
		fmt.Fprintln(os.Stderr, "Cannot read candidate file! ", err)
	}

	rand.Seed(time.Now().UnixNano())

	winners := make([]string, count)

	for i := 0; i < count; i++ {
		n := rand.Intn(len(candidates))
		winners[i] = candidates[n]
		candidates = append(candidates[:n], candidates[n+1:]...)
	}

	fmt.Println("Winners are !!!")
	for _, winner := range winners {
		fmt.Println(winner)
	}

}

func readCandidates(filename string) ([]string, error) {
	file, err := os.Open(filename)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)
	var candidates []string
	for scanner.Scan() {
		candidates = append(candidates, scanner.Text())
	}

	return candidates, nil
}
