using MySql.Data.MySqlClient; // "Usa el paquete para hablar con MySQL”
using Mysqlx.Crud;
using System.Data; // Para poder hacer operaciones con la tabla (mira el home)using Microsoft.AspNetCore.Identity.

namespace PracticaMySQL2.Components.Data
{
    public class AplicationDbContext
    {
        private readonly string MySQLConnectionString; //Crea una cadena de conexión. Es como el mapa para llegar a la base de datos

        public AplicationDbContext()
        {
            MySQLConnectionString = "Server=localhost;Port=3306;Database=inventario;Uid=root;Pwd=kakillama58;";
        }

        public void addProduct(string name, decimal price)
        {
            using var conn = new MySqlConnection(MySQLConnectionString);
            conn.Open();

            string query = "INSERT INTO inventory (name, price) VALUES (@name, @price)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("@price", price);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
