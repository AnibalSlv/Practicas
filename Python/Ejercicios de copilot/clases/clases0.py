class  persona:
    def __init__(self, name, age, genere):
        self.nombre = name
        self.edad = age
        self.sexo = genere
    
    def funcionx(self): #TODO Esto es importante poner el self
        print(f"el nombre es {self.nombre}\nLa edad es {self.edad}\nEl sexo es {self.sexo}")
        
persona("K", "???", "hombre").funcionx()

class persona2(persona):
    def __init__(self,name, age, genere, cedula, telefono):
        super().__init__(name, age, genere)
        self.identificacion = cedula
        self.telefono = telefono
        
    def funcionx2(self):
        print(f"\nprint lol? el nombre es {self.nombre}\nLa edad es {self.edad}\nEl sexo es {self.sexo}\n{self.identificacion}\n{self.telefono}\n")
        super().funcionx()
        
persona2("Juan", 25, "hombre", 1234, 987654321).funcionx2()