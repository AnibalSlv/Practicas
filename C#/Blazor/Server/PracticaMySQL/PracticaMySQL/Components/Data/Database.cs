using MySql.Data.MySqlClient; // "Usa el paquete para hablar con MySQL”
using Mysqlx.Crud;
using System.Data; // Para poder hacer operaciones con la tabla (mira el home)

namespace PracticaMySQL.Data
{
    public class Database
    {
        //El readonly hace que el objeto no pueda cambiar de valor durante su vida
        //MySQLConnectionString tomalo como para hacer un pasaporte, donde tiene toda la informacion para accder a la db y tablas
        private readonly string MySQLConnectionString; //Crea una cadena de conexión. Es como el mapa para llegar a la base de datos

        public Database()
        {
            MySQLConnectionString = "Server=localhost;Port=3306;Database=sakila;Uid=root;Pwd=kakillama58;";
        }   //➡️ Aquí se guarda el mapa:
            //- Server=localhost → La base está en esta misma máquina.
            //- Database=clinica → El nombre de la base.
            //- Uid=root → Usuario.
            //- Pwd=1234 → Contraseña.


        public DataTable GetActor()
        {
            // Es como decir: “Quiero una hoja de Excel en blanco para guardar datos que vienen de la db"
            // new DataTable crea una nueva tabla vacia lista para llenarse
            DataTable dt = new DataTable(); //Crea una tabla vacía para guardar los resultados
            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString)) // Crea una conexión con MySQL usando el mapa. using asegura que se cierre sola al final.
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM actor", conn); //Ey MySQL, tráeme todos los registros de la tabla .
                using (MySqlDataReader rdr = cmd.ExecuteReader()) // empieza a leer los datos que vienen
                {
                    dt.Load(rdr); //Carga los datos leídos en la tabla
                }
                conn.Close(); // Cierra la puerta: “Gracias MySQL, ya terminé”
            }
            return dt; // Devuelve la tabla con los actores
        }

        public void InsertarActor(string first_name, string last_name, DateTime date)
        {
            using var conn = new MySqlConnection(MySQLConnectionString);
            conn.Open();

            string query = "INSERT INTO actor (first_name, last_name, last_update) VALUES (@first_name, @last_name, @last_update)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@first_name", first_name);
            cmd.Parameters.AddWithValue("@last_name", last_name);
            cmd.Parameters.AddWithValue("@last_update", date);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int AddActor(string first_name, string last_name, DateTime date)
        {
            int recordsAffected = 0;
            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO actor (first_name, last_name, last_update) VALUES (@first_name, @last_name, @last_update)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@first_name", first_name);
                    cmd.Parameters.AddWithValue("@last_name", last_name);
                    cmd.Parameters.AddWithValue("@last_update", date);
                    recordsAffected = cmd.ExecuteNonQuery();
                }
            }
            return recordsAffected; // Devuelve cuántos registros se insertaron (debería ser 1 si OK)
        }

    }
}