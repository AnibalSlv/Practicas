// See https://aka.ms/new-console-template for more information

using ConsoleRiderPrueba;

float NumFloat(string prompt)
{
    Console.WriteLine(prompt);
    string? input = Console.ReadLine();
    if (float.TryParse(input, out float result))
    {
        return result;
    }
    else
    {
        Console.WriteLine("Invalid number, use 0 for default");
        return 0;
    }
}

int OptionCase()
{
    while (true)
    {
        Console.WriteLine("Write one option: ");
        Console.WriteLine("1.- Summary");
        Console.WriteLine("2.- Restart");
        Console.WriteLine("3.- Multiplication");
        Console.WriteLine("4.- Divider");

        string? input = Console.ReadLine();
        if (int.TryParse(input, out int opt) && (opt > 0 && opt < 5))
        {
            return opt;
        }
        Console.WriteLine("Invalid number, try again");
    }
}

float num  = NumFloat("Write first number");
float num2 = NumFloat("Write second number");

int option = OptionCase();

switch (option)
{
    case 1:
        Console.WriteLine($"The result is: {num + num2}");
        break;
    case 2:
        var message = (num > num2) ? $"The result is: {num - num2}" : $"The result is: {num2 - num}";
        Console.WriteLine(message);
        break;
    case 3:
        Console.WriteLine($"The result is: {num * num2}");
        break;
    case 4:
        Console.WriteLine($"The result is: {(num2 == 0 ? "Cannot divide by zero" : num / num2)}");
        break;
    default:
        Console.WriteLine($"The option {option} is invalid");
        break;
}

Animal animal = new Perro(); 
animal.Comer();

