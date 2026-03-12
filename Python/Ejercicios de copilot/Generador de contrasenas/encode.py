texto = "¡Hola!"
bytes_utf8 = texto.encode("utf-8")
bytes_ascii = texto.encode("ascii", errors="ignore")  # Ignora caracteres no ASCII

print("UTF-8:", bytes_utf8)
print("ASCII:", bytes_ascii)