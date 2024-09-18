using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static (int id,string nombre, string apellido, string obraSocial, string numeroObraSocial) BuscarPaciente(string dni)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, nombre, apellido, obra_social, numero_obra_social FROM Pacientes WHERE dni = @dni";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                id: reader.GetInt32(0),
                                nombre: reader.GetString(1),
                                apellido: reader.GetString(2),
                                obraSocial: reader.GetString(3),
                                numeroObraSocial: reader.GetString(4)
                            );
                        }
                        else
                        {
                            return (0, null, null, null,null);
                        }
                    }
                }
            }
        }


        public static void GuardarNuevoPaciente(string dni, string nombre, string apellido, string obraSocial, string numeroObraSocial)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Pacientes (dni, nombre, apellido, obra_social, numero_obra_social) VALUES (@dni, @nombre, @apellido, @obraSocial, @numeroObraSocial)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", dni);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.Parameters.AddWithValue("@obraSocial", obraSocial);
                    command.Parameters.AddWithValue("@numeroObraSocial", numeroObraSocial);
                    command.ExecuteNonQuery();
                }
            }
        }




        public static void GuardarTurno(int idPaciente, DateTime fechaHoraTurno)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Turnos (fecha, hora, id_paciente) VALUES (@fecha, @hora, @id_paciente)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fecha", fechaHoraTurno.Date); // Solo la fecha
                    command.Parameters.AddWithValue("@hora", fechaHoraTurno.ToString("HH:mm")); // Solo la hora
                    command.Parameters.AddWithValue("@id_paciente", idPaciente);
                    command.ExecuteNonQuery();
                }
            }
        }


        public static DataTable ObtenerTurnosPorFecha(DateTime fecha)
        {
            DataTable turnos = new DataTable();
            turnos.Columns.Add("hora", typeof(string));
            turnos.Columns.Add("nombre", typeof(string));
            turnos.Columns.Add("apellido", typeof(string));
            turnos.Columns.Add("obra_social", typeof(string));
            turnos.Columns.Add("numero_obra_social", typeof(string));

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Consulta SQL que obtiene la hora del turno y los datos del paciente asociado a una fecha específica
                string query = @"
                SELECT t.hora, p.nombre, p.apellido, p.obra_social, p.numero_obra_social
                FROM Turnos t
                JOIN Pacientes p ON t.id_paciente = p.id
                WHERE t.fecha = @fecha";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fecha", fecha.Date); // Filtrar por la fecha seleccionada

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataRow row = turnos.NewRow();
                            row["hora"] = reader.GetString(0); // Hora del turno
                            row["nombre"] = reader.GetString(1); // Nombre del paciente
                            row["apellido"] = reader.GetString(2); // Apellido del paciente
                            row["obra_social"] = reader.GetString(3); 
                            row["numero_obra_social"] = reader.GetString(4); 
                            turnos.Rows.Add(row);
                        }
                    }
                }
            }
            return turnos;
        }


    }
}
