package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

type task struct {
	ID       int
	text     string
	complete bool
}

var id int = 0
var tasks []*task

func CreateTask() {
	reader := bufio.NewReader(os.Stdin)  // bufio is one library for learn the input of user
	text, err := reader.ReadString('\n') // text, err (ReadString('\n') return the result, error) (the error is as "Try exception") (\n means when the user press enter)

	if err != nil {
		fmt.Println("Error: ", err)
	}

	text = strings.TrimSpace(text)
	id++
	t := &task{ID: id, text: text, complete: false}
	tasks = append(tasks, t)

}

func ShowTask() {
	for _, i := range tasks { // _, i ( _ ignore the index, i give values of range tasks ) (if you dont put it _ and put i Go it will say error)
		fmt.Printf("| ID: %d | Description: %s | Complete: %t |\n", i.ID, i.text, i.complete)
	}
}

func MarkTask(option int) {
	for _, i := range tasks {
		if i.ID == option {
			i.complete = true
		}
	}

}

func DeleteTask(option int) {
	for index, i := range tasks { //
		if i.ID == option {
			tasks = append(tasks[:index], tasks[index+1:]...) // Grabs the preceding elements ([:index]) and the following elements ([index + 1]) and joins the elements with ...
			break
		}
	}
}
