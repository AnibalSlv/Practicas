using Microsoft.Data.Sqlite;
using System.IO;

namespace MSistema_de_Control_de_Finanzas.Components.Services
{
    /// <summary>
    /// Servicio que agreaga datos sobre la finanza a la Base de datos SQLite / Service that add data about finance to the data base SQLite
    /// </summary>
    public class IncomeService
    {
        public void CreateTableIncome()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "finanzas.db");
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();

            ///Create table if it does not exist
            using (var tableCmd = connection.CreateCommand())
            {
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS money (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        context TEXT,
                        income TEXT,
                        amount NUMERIC,
                        metod TEXT,
                        d_start INTEGER,
                        d_final INTEGER
                    )";
                tableCmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserta un nuevo ingreso en la base de datos SQLite / Insert one new data in the data base SQLite.
        /// </summary>
        /// <param name="context">Descripción del ingreso / Description of income</param>
        /// <param name="income">Tipo de ingreso / Type of income</param>
        /// <param name="amount">Monto del ingreso en unidades monetarias / Mont of income in units monetarys</param>
        /// <param name="metod">Método de pago / Metod of pay</param>
        /// <param name="dStart">Fecha de inicio del ingreso (formato entero) / Start of date of income (format intenger)</param>
        /// <param name="dFinal">Fecha final del ingreso (formato entero) / End date of income (format intenger)</param>

        public void InsertIncome(string? context, string income, int amount, string metod, int dStart, int dFinal)
        {
            //Path.Combine junta la ruta del archivo + el archivo osea: /user/Lenovo/finanzas.db por ejemplo
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "finanzas.db");
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();

            ///Create table if it does not exist
            using (var tableCmd = connection.CreateCommand())
            {
                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS money (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        context TEXT,
                        income TEXT,
                        amount INTEGER,
                        metod TEXT,
                        d_start INTEGER,
                        d_final INTEGER
                    )";
                tableCmd.ExecuteNonQuery();
            }

            using var command = connection.CreateCommand(); //Es para poder usar otros comandos como ComandText
            //I use addDate to avoid repeating connection.CreateCommand(), I fell that it improves readability
            var addDate = command.Parameters;
            //Le dice: hey mira en la tabla money, columna context vas a dejar un hueco para @context luego te paso el valor
            command.CommandText = "INSERT INTO money (context, income, amount, metod, d_start, d_final) VALUES (@context, @income, @amount, @metod, @d_start, @d_final)";
            //Y aqui: el valor de @context = context y rellena el hueco
            addDate.AddWithValue("@context", context ?? "");
            addDate.AddWithValue("@income", income);
            addDate.AddWithValue("@amount", amount);
            addDate.AddWithValue("@metod", metod);
            addDate.AddWithValue("@d_start", dStart);
            addDate.AddWithValue("@d_final", dFinal);
            command.ExecuteNonQuery(); //Esto es como un INSERT
        }
    
        public async Task<List<IncomeModel>> ReadAllIncomeAsync()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "finanzas.db");
            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();
            
            string query = "SELECT context, income, amount, metod, d_start, d_final FROM money";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();
            var result = new List<IncomeModel>();
            
            while (reader.Read()) 
            {
                var item = new IncomeModel
                {
                    Context = reader.GetString(0),
                    Income = reader.GetString(1),
                    Amount = reader.GetDecimal(2),
                    Metod = reader.GetString(3),
                    DStart = reader.GetInt32(4),
                    DFinal = reader.GetInt32(5)
                };
                result.Add(item);
            }
            return result;
        }

    }
    public class IncomeModel
    {
        public string? Context { get; set; }
        public string Income { get; set; } = "error?";
        public decimal Amount { get; set; }
        public string? Metod { get; set; }
        public int DStart { get; set; }
        public int DFinal { get; set; }
    }
}