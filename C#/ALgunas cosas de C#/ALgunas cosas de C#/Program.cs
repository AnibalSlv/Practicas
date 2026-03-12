double total = funcion(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
Console.WriteLine(total);
double funcion(params double [] prices)
{
    double total = 0;
    foreach(double price in prices)
    {
        total += price;
    }
    Console.WriteLine(total);
    return total;
} //el params es cuando queremos pasar una n cantidad de datos a una funcion

int edad = 18;
string mensaje = (edad >= 18) ? "si" : "no"; //Esto es como un if pero mas simple se llama operador condicional ternario
Console.WriteLine(mensaje);

Console.WriteLine($"Hola tu edad es: {edad} \nEl precio random de hoy es: {total}");

Console.ReadKey(); //Esto es como para pausar la terminal 