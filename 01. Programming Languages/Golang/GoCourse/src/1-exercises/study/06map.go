package study

import (
	"errors"
	"fmt"
)

type user struct {
	name        string
	phoneNumber int
}

func Map() {

	userNames := []string{"김군", "박군", "이군"}
	phoneNumbers := []int{1234, 5678, 8989}

	userMap, err := getUserMap(userNames, phoneNumbers)

	if err != nil {
		fmt.Println("Error Happened")
		return
	}

	fmt.Println(userMap)

	myUser, ok := userMap["강군"]

	if ok {
		fmt.Println(myUser)
	} else {
		fmt.Println("그런 사람 없음")
	}

	yourUser, ok := userMap["이군"]

	if ok {
		fmt.Println(yourUser)
	}

	delete(userMap, "김군")

	fmt.Println(userMap)

	usrIds := []string{
		"a", "a", "a", "a", "a", "a", "a", "a", "B", "B", "B", "B", "B", "gg", "gg", "gg",
	}

	ccountMap := getCounts(usrIds)

	fmt.Println(ccountMap)
}

func getUserMap(names []string, phoneNumbers []int) (map[string]user, error) {
	userMap := make(map[string]user)

	if len(names) != len(phoneNumbers) {
		return nil, errors.New("invalid sizes")
	}

	for i := 0; i < len(names); i++ {
		userMap[names[i]] = user{
			name:        names[i],
			phoneNumber: phoneNumbers[i],
		}
	}
	return userMap, nil
}

func getCounts(userIds []string) map[string]int {
	counts := make(map[string]int)

	for _, userId := range userIds {
		counts[userId]++
	}
	return counts
}
