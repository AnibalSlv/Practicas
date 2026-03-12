using System.Text;
using System.Text.Json;

class Program
{
    static HttpClient client = new HttpClient();

    static async Task Main()
    {

        //Conection
        string url = "https://webhook.site/76611ca0-6a1c-4a5a-a45e-6b7e44029185";
        HttpResponseMessage response = await client.GetAsync(url);

        Console.WriteLine(response.StatusCode);

        //Post

        var NewPokemon = new
        {
            name = "Charmander",
            tipo = "Fuego",
            nivel = 1,
        };

        string json = JsonSerializer.Serialize(NewPokemon);

        var content = new StringContent(json, Encoding.UTF8, "application/json"); // ??????????????????

        var Response = await client.PostAsync(url,content);

        Console.WriteLine($"El Post mando: {await Response.Content.ReadAsStringAsync()}");

        //Get
        json = await response.Content.ReadAsStringAsync();
        var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

        Console.WriteLine($"El Pokemon es: {pokemon?.name}, de tipo: {pokemon?.tipo}, y de nivel: {pokemon?.nivel}");
    }
}

class Pokemon
{
    public string? name {  get; set; }
    public string? tipo { get; set; }
    public int nivel { get; set; }
}