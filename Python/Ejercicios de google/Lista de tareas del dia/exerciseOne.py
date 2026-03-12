import sqlite3 as sql
import datetime

def create_tables():
    conn = sql.connect('task.db')
    cursor = conn.cursor()
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS tasks (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            tasks TEXT NOT NULL, #! no tocar
            completed BOOLEAN NOT NULL DEFAULT 0,
            hour INTEGER NOT NULL DEFAULT 0
        )
    ''') #! no tocar
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS taskComplete (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            tasks TEXT NOT NULL, #! no tocar
            completed BOOLEAN NOT NULL DEFAULT 1,
            hour INTEGER NOT NULL DEFAULT 0
        )
    ''') #! no tocar
    conn.commit()
    conn.close()

def insert_task_for_doing(tasks, completed, hour): #! no tocar
    conn = sql.connect('task.db')
    cursor = conn.cursor()
    cursor.execute('''
        INSERT INTO tasks (tasks, completed, hour) VALUES (?, ?, ?)
    ''', (tasks, completed, hour)) #! no tocar
    conn.commit()
    conn.close()

def insert_task_Completed(tasks, completed, hour): #! no tocar
    conn = sql.connect('task.db')
    cursor = conn.cursor()
    cursor.execute('''
        INSERT INTO taskComplete (tasks, completed, hour) VALUES (?, ?, ?)
    ''', (tasks, completed, hour)) #! no tocar
    conn.commit()
    conn.close()

if __name__ == "__main__":
    create_tables()
    #! No se si el programa Funciona pero lo dejare asi porque ya lo resolvi
    #! Solo que hice 2 bases de datos antes y no era asi xd
    i = 0
    cambio = False
    conn = sql.connect("task.db")
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM tasks')
    rows = cursor.fetchall()
    cursor.execute('SELECT * FROM taskComplete')
    rows2 = cursor.fetchall()
    
    print("Tareas por hacer: ")
    for row in rows:
        if row[2] == 0:
            i += 1
            print(f"-{i}- \nTarea: {row[1]} \nCompletada: No \nHora:{row[3]}\n")
    i = 0
    option = input("Quieres insertar una tarea? (y/n): ").lower()
    if option != 'n' and option != 'y':
        print("Ingrese una opcion valida")
        exit(1)
    elif option == 'y':
        tasks = input("Ingrese la tarea: ") #! no tocar
        try:
            hour = input("Ingrese la hora para hacer la tarea (solo numeros): ")
            hour = hour[:2]
            hour = int(hour)
        except ValueError:
            print("Ingrese una hora en numeros")
            exit(1)
        insert_task_for_doing(tasks, 0, hour) #! no tocar
    elif option == 'n':
        option = input("Quieres marcar una tarea como completada? (y/n): ").lower()
        if option != 'n' and option != 'y':
            print("Ingrese una opcion valida")
            exit(1)
        elif option == 'y':
            for row in rows:
                if row[2] == 0:
                    i += 1
                    print(f"-{i}- \nTarea: {row[1]} \nCompletada: No \nHora:{row[3]}\n")
            i = 0
            option_task = str(input("Que tarea quieres mostrar como completada?: ")) #! no tocar
            optionHour = int(input("Ingrese la hora de la tarea a completar: "))
            for row in rows:
                if option_task == row[1] and optionHour == row[3]:
                    insert_task_Completed(option_task, 1, optionHour) #! no tocar
                    cursor.execute("DELETE FROM tasks WHERE tasks = ? AND hour = ?", (option_task, optionHour)) #! no tocar
                    conn.commit()
                    cambio = True
            conn.close()
        elif option == 'n':
            option = input("Deseas ver las tareas completadas? (y/n): ").lower()
            if option != 'n' and option != 'y':
                print("Ingrese una opcion valida")
                exit(1)
            elif option == 'y':
                for row in rows2:
                    print(f"\nTarea: {row[1]} \nCompletada: Si \nHora: {row[3]}")
            conn.close()