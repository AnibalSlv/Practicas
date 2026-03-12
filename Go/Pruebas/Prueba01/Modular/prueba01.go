package main

import (
	"fmt"
)

func main() {
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

			CreateTask()

		case 2:
			ShowTask()
			fmt.Println("\nWant complete one task?")
			fmt.Println("1.- Yes")
			fmt.Println("2.- No:  ")
			fmt.Scan(&option)
			switch option {
			case 1:
				fmt.Println("Select the task for complete (The number): ")
				fmt.Scan(&option)
				MarkTask(option)
			case 2:
				break
			default:
				fmt.Println("Option not exists")
			}

		case 3:
			fmt.Println("Select the task for delete (The number): ")
			fmt.Scan(&option)
			DeleteTask(option)
		case 4:
			exit = 1

		default:
			fmt.Println("The option selected not is valid")
		}
	}
}
