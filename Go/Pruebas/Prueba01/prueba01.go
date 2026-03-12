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

func main() {
	var tasks []*task
	var id int
	var option int = 0

	fmt.Println("Welcome at the program beginner of go create by I")
	for exit := 0; exit == 0; {
		fmt.Println("\n1.- Create Task")
		fmt.Println("2.- Consult task")
		fmt.Println("3.- Delete Task")
		fmt.Println("4.- Exit: ")
		fmt.Scan(&option)

		switch option {
		case 1:
			fmt.Println("\nAdd one task")
			fmt.Println("Enter task description")
			fmt.Scanln() //? Clear the buffer (The buffer stores the previously pressed enter key and further down it evaluates if it was pressed)

			reader := bufio.NewReader(os.Stdin)  // bufio is one library for learn the input of user
			text, err := reader.ReadString('\n') // text, err (ReadString('\n') return the result, error) (the error is as "Try exception") (\n means when the user press enter)
			if err != nil {
				fmt.Println("Error: ", err)
			}
			text = strings.TrimSpace(text)
			id += 1
			t := &task{ID: id, text: text, complete: false}
			tasks = append(tasks, t)

		case 2:
			for _, i := range tasks { // _, i ( _ ignore the index, i give values of range tasks ) (if you dont put it _ and put i Go it will say error)
				fmt.Printf("| ID: %d | Description: %s | Complete: %t |\n", i.ID, i.text, i.complete)
			}
			fmt.Println("\nWant complete one task?")
			fmt.Println("1.- Yes")
			fmt.Println("2.- No:  ")
			fmt.Scan(&option)
			switch option {
			case 1:
				fmt.Println("Select the task for complete (The number): ")
				fmt.Scan(&option)
				for _, i := range tasks {
					if i.ID == option {
						i.complete = true
					}
				}

			case 2:
				break
			default:
				fmt.Println("Option not exists")
			}

		case 3:
			fmt.Println("Select the task for delete (The number): ")
			fmt.Scan(&option)
			for index, i := range tasks { //
				if i.ID == option {
					tasks = append(tasks[:index], tasks[index+1:]...) // Grabs the preceding elements ([:index]) and the following elements ([index + 1]) and joins the elements with ...
					break
				}
			}

		case 4:
			exit = 1

		default:
			fmt.Println("The option selected not is valid")
		}
	}
}
