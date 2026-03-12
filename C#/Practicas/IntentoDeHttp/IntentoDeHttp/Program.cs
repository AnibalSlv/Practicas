
using System.Data.Common;
using System.Reflection;
using System.Text.Json;
using System.Threading.Channels;

class Program //Very important encapsule the http in one class for what no give error out class
{
    static HttpClient client = new HttpClient(); //Whit this we can generate request, this is create one time

    static async Task Main()
    {
        Console.WriteLine("Coloca el nombre o ID del pokemon");
        string identifier = Console.ReadLine() ?? "";
        
        string url = $"https://pokeapi.co/api/v2/pokemon/{identifier}";
        HttpResponseMessage response = await client.GetAsync(url); //This is one request Get

        if (response.IsSuccessStatusCode)//Verify what the response is successful
        {
            var json = await response.Content.ReadAsStringAsync(); //Read the content whit text
            var pokemon = JsonSerializer.Deserialize<Pokemon>(json);//Acces to the object of Json having as template the class Pokemon for obtain the values

            Console.WriteLine($"ID: {pokemon?.id ?? 0}");
            Console.WriteLine($"Nombre: {pokemon?.name ?? "No hay pokemon"} "); //? is for to say if this value no is null return .name but if is null return "no hay pokemon"
            Console.Write("Tipo: ");
            foreach (var t in pokemon.types)
            {
                Console.Write($"{t.type.name} ");
            }
            Console.WriteLine();
        }
        else { 
            Console.WriteLine(response.StatusCode);
        }
    }
}

class Pokemon //The class is mandatory for the JSON to read it (just include the necessary properties or use Visual Studio to get the code in the class (I think))
{
    public int id { get; set; }
    public string name { get; set; }
    public List<TypeContainer> types {  get; set; }
}

class TypeContainer
{
    public TypeInfoPokeApi type { get; set; }
}

class TypeInfoPokeApi
{
    public string name {  set; get; }
}