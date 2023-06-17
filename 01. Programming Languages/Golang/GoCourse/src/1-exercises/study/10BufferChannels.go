package study

import "fmt"

func Buffers() {
	testBuffer("Hello John, tell Kathy I said hi", "Whazzup bruther")
	testBuffer("I find that hard to believe.", "When? I don't know if I can", "What time are you thinking?")
	testBuffer("She says hi!", "Yeah its tomorrow. So we're good.", "Cool see you then!", "Bye!")
}

func testBuffer(emails ...string) {
	fmt.Printf("Adding %v emails to queue...\n", len(emails))
	ch := addEmailsToQueue(emails)
	fmt.Println("Sending emails...")
	sendEmails(len(emails), ch)
	fmt.Println("==========================================")
}

func sendEmails(batchSize int, ch chan string) {
	for i := 0; i < batchSize; i++ {
		email := <-ch
		fmt.Println("Sending email:", email)
	}
}

func addEmailsToQueue(emails []string) chan string {
	emailsToSend := make(chan string, len(emails)) //여기서 Buffer 수량을 맞춰줘야 함. // 그런데 이런 방식은 잘 쓰지 않으면 데드락 걸리기 쉽겠다.
	for _, email := range emails {
		emailsToSend <- email
	}
	return emailsToSend
}
