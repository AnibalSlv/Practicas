import re

# Función para quitar números de un texto
def quitar_numeros(texto):
    return re.sub(r'\d+', '', texto)  # Reemplaza todos los dígitos con una cadena vacía

# Ruta del archivo de entrada y salida
archivo_entrada = 'es_50k.txt'
archivo_salida = 'es_50k_salida.txt'

# Leer el contenido del archivo
with open(archivo_entrada, 'r', encoding='utf-8') as file:
    contenido = file.read()

# Quitar los números del contenido
contenido_sin_numeros = quitar_numeros(contenido)

# Escribir el contenido modificado en un nuevo archivo
with open(archivo_salida, 'w', encoding='utf-8') as file:
    file.write(contenido_sin_numeros)

print("Los números han sido eliminados y el nuevo contenido se ha guardado en", archivo_salida)
