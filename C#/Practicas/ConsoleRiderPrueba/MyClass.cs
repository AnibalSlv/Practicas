namespace ConsoleRiderPrueba;

public class Animal
{
    public void Comer()
    {
        Console.WriteLine("El animal está comiendo.");
    }
}
public class Perro : Animal
{
    public void Ladrar()
    {
        Console.WriteLine("El perro está ladrando.");
    }
}