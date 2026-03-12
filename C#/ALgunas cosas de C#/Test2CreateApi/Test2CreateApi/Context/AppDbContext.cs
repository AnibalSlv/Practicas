using Microsoft.EntityFrameworkCore;
using Test2CreateApi.Models;

namespace Test2CreateApi.Context;

public class AppDbContext : DbContext
{
    // La clase base le pasa la propiedad options al constructor (es lo que entiendo)
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
        
    }
    
    // DbSet es una clase en Entity Framework que representa una coleccion de entidades en este conjunto
    // TODO: En este contexto entidades se refiere a las clases que representan objetos o modelos de datos en la pp
    // TODO: cada instancia de esta clase corresponde a una fila relacionada a la Db
    public DbSet<Person> Persons { get; set; } // Es buena práctica colocarlo en plural
}