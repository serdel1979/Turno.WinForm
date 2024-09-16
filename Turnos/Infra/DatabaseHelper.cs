using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Infra
{
    public class DatabaseHelper
    {

        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clinica.db");
        private static string connectionString = $"Data Source={dbPath}";

        public static void InicializarBaseDeDatos()
        {


            // Crear las tablas
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string tablaPacientes = @"
                CREATE TABLE IF NOT EXISTS Pacientes (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    dni TEXT NOT NULL,
                    nombre TEXT NOT NULL,
                    apellido TEXT NOT NULL,
                    obra_social TEXT,
                    numero_obra_social TEXT
                );";

                string tablaTurnos = @"
                CREATE TABLE IF NOT EXISTS Turnos (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    fecha DATE NOT NULL,
                    hora TIME NOT NULL,
                    id_paciente INTEGER,
                    FOREIGN KEY(id_paciente) REFERENCES Pacientes(id)
                );";

                string tablaUsers = @"
                CREATE TABLE IF NOT EXISTS Users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    username TEXT NOT NULL,
                    password TEXT NOT NULL
                );";

                using (var command = new SqliteCommand(tablaPacientes, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqliteCommand(tablaTurnos, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SqliteCommand(tablaUsers, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insertar el usuario por defecto si no existe
                string insertUser = @"
                INSERT INTO Users (username, password)
                SELECT 'user', 'user'
                WHERE NOT EXISTS (SELECT 1 FROM Users WHERE username = 'user');";

                using (var command = new SqliteCommand(insertUser, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }


        public static bool VerificarCredenciales(string username, string password)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE username = @username AND password = @password";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }


        public static bool BuscaPacient(string dni)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Pacientes WHERE dni = @dni";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static (string nombre, string apellido, string obraSocial, string numeroObraSocial) BuscarPaciente(string dni)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nombre, apellido, obra_social, numero_obra_social FROM Pacientes WHERE dni = @dni";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                nombre: reader.GetString(0),
                                apellido: reader.GetString(1),
                                obraSocial: reader.GetString(2),
                                numeroObraSocial: reader.GetString(3)
                            );
                        }
                        else
                        {
                            return (null, null, null, null);
                        }
                    }
                }
            }
        }

    }
}
