import sqlite3 as sql
#!-------------- Completado Solo recuerda sacar la base de datos de la carperta :P ----------------
def create_table_contact():
    conn = sql.connect("BContact.db")
    cursor = conn.cursor()
    cursor.execute('''
                   CREATE TABLE IF NOT EXISTS contact(
                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                       name TEXT NOT NULL,
                       telf INTEGER NOT NULL
                   )
                   ''')
    cursor.execute('''
                   CREATE TABLE IF NOT EXISTS blackList(
                       id INTEGER PRIMARY KEY AUTOINCREMENT,
                       name TEXT NOT NULL,
                       telf INTEGER NOT NULL
                   )
                   ''')
    conn.commit
    conn.close

def create_row_contact(name, telf):
    conn = sql.connect("BContact.db")
    cursor = conn.cursor()
    cursor.execute('''
                INSERT INTO contact (name, telf) VALUES (?, ?)
                ''', (name, telf))
    conn.commit()
    conn.close()

def create_row_blackList(name, telf):
    conn = sql.connect("BContact.db")
    cursor = conn.cursor()
    cursor.execute('''
                   INSERT INTO blackList(name, telf) VALUES(?, ?)
                   ''',(name, telf))
    conn.commit()
    conn.close()

if __name__ == "__main__":
    create_table_contact()
    i = 0
    conn = sql.connect("BContact.db")
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM contact')
    rows = cursor.fetchall()
    
    option = int(input("Que quieres hacer?\n1.-Añadir contacto\n2.-Eliminar contacto\n3.-Bloquear contacto\n4.-Desbloquear contacto\n5.-Ver lista de contacto\n6.-Ver lista de contactos bloqueados\n"))
    if option < 1 or option > 6:
        print("Ingrese un dato valido")
        exit(1)
    elif option == 1: #TODO Crear contacto
        name = input("Ingrese un nombre (max 16 caracteres): ").title()[:16]
        try:
            telf = int(input("Ingrese un numero telefonico: "))
        except ValueError:
            print("Ingrese un dato valido")
            exit(1)
        create_row_contact (name, telf)
        print("Contacto añadido")
    elif option == 2: #TODO Eliminar contacto
        name = input("Ingrese el nombre del contacto: ").title()
        telf = int(input("Ingrese el numero telefonico: "))
        for row in rows:
            if row[1] == name and row[2] == telf:
                cursor.execute('''DELETE FROM contact WHERE name = ? AND telf = ?''', (name, telf))
        print("Contacto eliminado")
        conn.commit()
        conn.close()
    elif option == 3: #TODO Bloquear contacto
        for row in rows:
            i += 1
            print(f"\n-{i}-\nContacto: {row[1]}\nTelefono: {row[2]}")            
        name = input("Que contacto quieres bloquear? (Ingrese nombre): ")
        telf = int(input("Ingrese el numero telefonico: "))
        for row in rows:
            if row[1] == name and row[2] == telf:
                print("Se ejecuto")
                cursor.execute('''
                            INSERT INTO blackList (name, telf)
                            SELECT name, telf
                            FROM contact
                            WHERE name = ? AND telf = ?
                            ''',(name, telf)) #? El where es para especificar que esos son los datos
                #? Que quiero cambiar
                cursor.execute('''
                               DELETE FROM contact WHERE name = ? AND telf = ?
                               ''', (name, telf))
                print("Contacto movido")
                conn.commit() #! RECUERDA PONER PARENTESIS!!!!!!!!!!!!!
                conn.close()
    elif option == 4: #TODO Desbloquear contacto
        cursor.execute('''SELECT * FROM blackList''')
        rows = cursor.fetchall() #! RECUERDA PONER PARENTESIS!!!!!!!!!!!!!!!!
        for row in rows:
            i += 1
            print(f"\n-{i}-\nContacto: {row[1]}\nTelefono: {row[2]}")
        name = input("Ingrese el nombre: ")
        telf = int(input("Ingrese el numero telefonico: "))
        for row in rows:
            print("ok?")
            if row[1] == name and row[2] == telf:
                print("Ya se ejecuto")
                cursor.execute('''
                               INSERT INTO contact (name, telf)
                               SELECT name, telf
                               FROM blackList
                               WHERE name = ? AND telf = ?
                               ''',(name, telf))
                
                cursor.execute('''
                               DELETE FROM blacklist WHERE name = ? AND telf = ?
                               ''',(name, telf))
        print("Contacto movido")
        conn.commit()
        conn.close()
    elif option == 5: #TODO Ver lista de contacto
        for row in rows:
            i += 1
            print(f"{i} {row[1]} {row[2]}")
        conn.close()
        
    elif option == 6: #TODO Ver lista de bloqueados
        rows = cursor.execute('''SELECT * FROM blackList''').fetchall() #!PARENTESIS!!!!!!!
        for row in rows:
            i += 1
            print(f"{i} {row[1]} {row[2]}")
        conn.close()