namespace CreateTestAPI.Models;
using Microsoft.EntityFrameworkCore;

public class TodoContext : DbContext // DbContext es un recurso externo
{
    // El contexto de base de datos es la clase principal que coordina la funcionalidad de Entity Framework
    public TodoContext(DbContextOptions<TodoContext> options) : base(options){}
    public DbSet<TodoItem> TodoItems { get; set; } = null!; 
}

//TODO: Recuerda que lo tienes que declarar en Program.cs pq es un servicio pos

