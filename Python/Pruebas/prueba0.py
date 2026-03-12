import sqlite3 as sql

def create_table(): #TODO Aquí se crea la tabla
    conn = sql.connect("prueba0.db")
    cursor = conn.cursor() #? Sirve para ejecutar comandos SQL
    cursor.execute('''
        CREATE TABLE IF NOT EXISTS users (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT NOT NULL,
            age INTEGER NOT NULL
        )
    ''')  # <-- Aquí cierran las comillas triples y el paréntesis juntos
    conn.commit()
    conn.close()

def insert_row(name, age): #TODO Aquí se crea la columna
    # y se insertan los datos
    conn = sql.connect("prueba0.db")
    cursor = conn.cursor()
    cursor.execute('''
        INSERT INTO users (name, age) VALUES (?, ?)
    ''', (name, age))  #? <-- Los ?? son marcadores de posición ademas evitan inyecciones SQL
    #? <-- Name y Age sirven para decirle que estos son los valores reales para poner en ??
    conn.commit()
    conn.close()

def query_database(): #TODO Aquí se consulta la base de datos
    conn = sql.connect("prueba0.db")
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM users')
    rows = cursor.fetchall() #? <-- Aquí se obtienen todas las filas
    option = input("Quieres imprimir la tabla normal? (y/n): ")
    if option.lower() == 'y' or option.lower() == 'n':
        if option.lower() == 'y':
            for row in rows: #? <-- Aquí se itera sobre las filas y se imprimen
                print(row)
                conn.close()
        elif option.lower() == 'n': #! Aqui comienza el filtro
            filter = input("Quieres filtrar por nombre? (y/n):")
            if filter.lower() != 'y' and filter.lower() != 'n':
                print("porfavor ingrese una opcion valida")
                exit(1)
            elif filter.lower() == 'y':
                nameFiltro = input("Ingrese el nombre a filtrar: ")
                if nameFiltro == "":
                    print("No ingresaste un nombre.")
                    exit(1)
                else:
                    for row in rows:
                        if nameFiltro.lower() in row[1].lower(): #? <-- in es "en" en espanol
                          print(row)
                    conn.close()
            else:
                try:
                    ageFiltro = int(input("Ingrese la edad a filtrar: "))
                except ValueError:
                    print("Por favor ingrese una edad validad.")
                    exit(1)
                if ageFiltro == "":
                    print("No ingresaste una edad.")
                    exit(1)
                elif ageFiltro < 0 or ageFiltro > 120:
                    print("La edad tiene que ser validad.")
                    exit(1)
                else:
                    for row in rows:
                        if ageFiltro == row[2]:
                            print(row)
                    print("\n Ahora se mostrara ordenada \n")
                    filtered_rows = [row for row in rows if ageFiltro == row[2]] #? Entender mejor
                    for row in sorted(filtered_rows, key=lambda x: x[1]): #? Entender mejor
                        if ageFiltro == row[2]:
                            print(row)
                    conn.close()
                    
                
                
    else:
        print("Ingrese una opcion valida.")
        conn.close()
        exit(1)

if __name__ == "__main__":
    option = input("Quieres registrarte en la base de datos? (y/n): ")
    if option.lower() != 'y' and option.lower() != 'n':
            print("por favor ingrese un dato valido.")
            exit(1)
    elif option.lower() == 'y':
        try: #? esto es para evitar que el programa se caiga si el usuario no ingresa un dato correcto
            name = input("Ingrese su nombre: ") #! Desde aqui empieza el registro
            if name == "":
                print("No ingresaste un nombre.") 
                exit(1)
            age = int(input("Ingrese su edad: "))
            if age < 0 and age > 120:
                print("La edad tiene que ser validad.")
                exit(1)
        except ValueError:
            print("Por favor ingrese una edad.")
            exit(1)
        if name and age:
            create_table()
            insert_row(name, age)
            query_database()
    else:
        option = input("Quieres consultar la base de datos? (y/n): ") #! Aqui se consulta la base de datos
        if option.lower() != 'y' and option.lower() != 'n':
            print("porfavor ingrese una opcion valida")
            exit(1)
        else:
            if option.lower() == 'n':
                print("No se consultó nada.")
                exit(0)
            else:
                query_database()
    
    