using MethodHttp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

// !NOTA EL MODO DEBUG FUNCIONA CUANDO LE DA LA GANA POR SER ASYNC O NO SE (PRINCIPAL PROBLEMA CON EL PUT)

// Aqui colocas la url de la API
string url = "http://localhost:5009/api/person";

string urlId = "http://localhost:5009/api/person/4";

// Con esto haces un puente entre tu programa y la API
HttpClient client= new HttpClient();

// Aquí obtienes acceso a la API
var HttpResponse = await client.GetAsync(url);

async Task MethodGet()
{
    // Verificas si pudo entrar (Es decir obtienes algún codigo del 200 a 299 si no, no se ejecuta
    if (HttpResponse.IsSuccessStatusCode)
    {
        // Entra al contenido de la API y saco los datos en formato texto
        var content = await HttpResponse.Content.ReadAsStringAsync();
        
        // Cambias una opcion para que si hay 2 datos diferentes (por ejemplo Id != id) los concidere iguales
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        // Convierte el texto en una lista tipo objeto (person), options es para lo antes mencionado
        var post = JsonSerializer.Deserialize<List<Person>>(content, options);
    
        foreach (var p in post)
        {
            var x = p.Id;
            Console.WriteLine($"Id: {p.Id}\nName: {p.Name}\nAge: {p.Age}");
        }
        
        // Es para que el programa no se cierre y probar el modo debug (en realidad no hace falta)
        Console.ReadKey();
    }
}

// MethodGet();

async Task MethodPost()
{
    Person person = new Person()
    {
        Name = "Aranza Valiente",
        Age = 52
    };
    
    // Convertimos el objeto Person en un Json
    var data = JsonSerializer.Serialize(person);
    
    // Decimos como enviamos: contenido, el formato en que lo envias (en general se envia como UTF8), el tipo de contenido
    // El tipo de contenido tiene que ser asi tal cual para que el servicio sepa que estás enviando un Json
    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

    // Esta variable nos permite hacer un Post
    var httpResponse = await client.PostAsync(url, content);
    
    /*
        Todo: segun la IA asi se escribe mas directo el envio y no tengo que hacer el dat y el content 
            - var httpResponse = await client.PostAsJsonAsync(url, person);
    */
    if(httpResponse.IsSuccessStatusCode)
    {
        // Obtiene el resultado que envío el metodo Post
        var result = await httpResponse.Content.ReadAsStringAsync();
        
        // Transforma de Json a formato texto. Esto para obtener como resultado lo que enviamos pero con las modificaciones
        // que se hacen al enviarlo por ejemplo: al enviar este objeto la base de datos le asigna una id
        // asi que PostResult tendria la id que le asigna la db y los datos que enviamos
        var PostResult = JsonSerializer.Deserialize<Person>(result);
        
        /*
            TODO: Se supone que es una forma mas moderna
                - var postResult = await httpResponse.Content.ReadFromJsonAsync<Person>();
        */   
    }
}

MethodPost();

async Task MethodPut()
{
    Person person = new Person()
    {
        Id = 1, // ! IMPORTENTE COLOCAR LA ID QUE QUEREMOS CAMBIAR 
        Name = "Juanito Casas",
        Age = 16
    };

    // Convertimos el objeto Person en un Json
    var data = JsonSerializer.Serialize(person);

    // Decimos como enviamos: contenido, el formato en que lo envias (en general se envia como UTF8), el tipo de contenido
    // El tipo de contenido tiene que ser asi tal cual para que el servicio sepa que estás enviando un Json
    HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

    // Esta variable nos permite hacer un Put
    var httpResponse = await client.PutAsync(urlId, content);

    /*
        TODO: Depende de la Api a veces regresa o no algo ( en mi api de practica no regresa )
        
        if(httpResponse.IsSuccessStatusCode)
        {
            // Obtiene el resultado que envío el metodo Post
            var result = await httpResponse.Content.ReadAsStringAsync();
        
            // Transforma de Json a formato texto. Esto para obtener como resultado lo que enviamos pero con las modificaciones
            // que se hacen al enviarlo por ejemplo: al enviar este objeto la base de datos le asigna una id
            // asi que PostResult tendria la id que le asigna la db y los datos que enviamos
            
            var PostResult = JsonSerializer.Deserialize<Person>(result);
        }
    */
}

// await MethodPut();

async Task MethodDelete(){
    var httpResponse = await client.DeleteAsync(urlId);
    
    // TODO: Depende de la Api a veces regresa o no algo ( en mi api de practica no regresa )
}

// await MethodDelete();

Console.ReadKey();

