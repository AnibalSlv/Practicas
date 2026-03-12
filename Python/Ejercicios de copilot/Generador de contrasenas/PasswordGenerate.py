import secrets
import string


def generador(longitud):
    contrasena = string.ascii_letters + string.digits + string.punctuation
    resultado = ''.join(secrets.choice(contrasena) for i in range(longitud))
    print(resultado)
longitud = int(input ("De que tamano quieres la clave?"))
generador(longitud)