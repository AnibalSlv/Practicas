namespace SistemaDePacientes.Components.Modules;

public class Patient
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string LastName {get; set;}
    public int Age { get; set; }
    public string AttetionLevel {get; set;}
    
    public Patient( int id, string name, string lastname, int age, string attetionLevel)
    {
        this.Id = id;
        this.Name = name;
        this.LastName = lastname;
        this.Age = age;
        this.AttetionLevel = attetionLevel;
    }
}