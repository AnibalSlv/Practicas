# Crear y escribir en un archivo
with open("archivo.txt", "w") as archivo:
    archivo.write("Hola, este es un archivo de prueba.")

# Leer archivo
with open("archivo.txt", "r") as archivo:
    contenido = archivo.read()
    print(contenido)  # ➝ Hola, este es un archivo de prueba.

import json

datos = {"usuario": "Juan", "edad": 30}
# Guardar en archivo JSON
with open("datos.json", "w") as archivo:
    json.dump(datos, archivo)

# Leer archivo JSON
with open("datos.json", "r") as archivo:
    datos_cargados = json.load(archivo)
    print(datos_cargados)  # ➝ {'usuario': 'Juan', 'edad': 30}
    
import csv

datos = [["Nombre", "Edad", "Ciudad"], ["Tulio", 43, "Caracas"], ["Anna", 19, "Cumana"]]
with open("datos.csv", "a", newline="") as archivo:
    escritor = csv.writer(archivo)
    escritor.writerows(datos)
    
with open("datos.csv", "r") as archivo:
    lector = csv.reader(archivo)
    for fila in lector:
        print(fila)