import threading

def mostrar_mensaje():
    print("¡Hola desde otro hilo!")

# Crear y ejecutar un hilo
hilo = threading.Thread(target=mostrar_mensaje)
hilo.start()