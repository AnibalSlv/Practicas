namespace Test2CreateApi.Models;

// get permite obtener los datos afuera de la clase
// set permite modificar los datos afuera de la clase

public class Person
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
}   