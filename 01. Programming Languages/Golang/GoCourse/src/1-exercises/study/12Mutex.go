package study

import (
	"fmt"
	"sort"
	"sync"
	"time"
)

func MutexSample() {
	sc := safeCounter{
		counts: make(map[string]int),
		mux:    &sync.RWMutex{},
	}
	testMutex(sc, []emailTest{
		{
			email: "john@example.com",
			count: 23,
		},
		{
			email: "john@example.com",
			count: 29,
		},
		{
			email: "jill@example.com",
			count: 31,
		},
		{
			email: "jill@example.com",
			count: 67,
		},
	})
	testMutex(sc, []emailTest{
		{
			email: "kaden@example.com",
			count: 23,
		},
		{
			email: "george@example.com",
			count: 126,
		},
		{
			email: "kaden@example.com",
			count: 31,
		},
		{
			email: "george@example.com",
			count: 453,
		},
	})
}

type safeCounter struct {
	counts map[string]int
	mux    *sync.RWMutex
}

func (sc safeCounter) inc(key string) {
	sc.mux.Lock()
	defer sc.mux.Unlock()
	sc.slowIncrement(key)
}

func (sc safeCounter) val(key string) int {
	sc.mux.RLock()
	defer sc.mux.RUnlock()
	return sc.counts[key]
}

func (sc safeCounter) slowIncrement(key string) {
	tempCounter := sc.counts[key]
	time.Sleep(time.Microsecond)
	tempCounter++
	sc.counts[key] = tempCounter
}

type emailTest struct {
	email string
	count int
}

func testMutex(sc safeCounter, emailTests []emailTest) {
	emails := make(map[string]struct{})

	var wg sync.WaitGroup
	for _, emailT := range emailTests {
		emails[emailT.email] = struct{}{}
		for i := 0; i < emailT.count; i++ {
			wg.Add(1)
			go func(emailT emailTest) {
				sc.inc(emailT.email)
				wg.Done()
			}(emailT)
		}
	}
	wg.Wait()

	emailsSorted := make([]string, 0, len(emails))
	for email := range emails {
		emailsSorted = append(emailsSorted, email)
	}
	sort.Strings(emailsSorted)

	for _, email := range emailsSorted {
		fmt.Printf("Email: %s has %d emails\n", email, sc.val(email))
	}
	fmt.Println("=====================================")
}
