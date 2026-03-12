namespace AVWintory.Components.Modules;

public class User
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public string Password { get; set; }
    public string Rol { get; set; }

    public User(int id, string name, string password, string rol)
    {
        this.Id = id;
        this.Name = name;
        this.Password = password;
        this.Rol = rol;
    }
}