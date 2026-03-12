import hashlib

texto = 'esto esta cifrado'
prueba = hashlib.sha512(texto.encode())
print(prueba)