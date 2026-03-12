using System;
using System.Collections.Generic;
using System.Linq;

// 1. Datos de prueba
List<Prueba> ListPrueba = new List<Prueba>() 
{
    new Prueba("Venta A", 20),
    new Prueba("Venta B", 35),
    new Prueba("Venta C", 10),
    new Prueba("Venta C", 10),
    new Prueba("Venta C", 10),
    new Prueba("Venta C", 10),
    new Prueba("Venta C", 10),
};

// 2. Extraer las edades al arreglo decimal[]
decimal[] data = ListPrueba.Select(s => (decimal)s.Age).ToArray();

// 3. Imprimir (Corregido \n y nombre de variable)
// Usamos string.Join para que se vean todos los números del arreglo
Console.WriteLine($"\nContenido del arreglo: {string.Join(", ", data)}");

// 4. Definición de la clase (Al final)
class Prueba
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Prueba(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}