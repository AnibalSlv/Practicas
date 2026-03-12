using CRUD.Shared; //El proyecto hace referencia a CRUD.Shared
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Data
{
    public class DataContext : DbContext
    {
    public DataContext() 
        { 
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
