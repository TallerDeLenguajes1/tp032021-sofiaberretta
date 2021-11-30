using Cadeteria.Models.Clases;
using Cadeteria.Models.DB;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models.RepoSQLite
{
    public class RepositorioUsuarioSQLite : IUsuarioDB
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioUsuarioSQLite(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void guardarUsuario(Usuario usuario)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO Usuarios (usuarioNombre, usuarioPassword)" +
                                   "VALUES (@usuarioNombre, @usuarioContrasenia);";

                using (SQLiteCommand command = new SQLiteCommand(sqlQuery, conexion))
                {
                    command.Parameters.AddWithValue("@usuarioNombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@usuarioContrasenia", usuario.Contrasenia);

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            
        }

        public int getUsuarioId(string nombre, string pass)
        {
            int usuarioID = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                 string sqlQuery = "SELECT usuarioID FROM Usuarios WHERE usuarioNombre = @usuarioNombre AND usuarioPassword = @usuarioContrasenia;";

                 using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                 {
                     command.Parameters.AddWithValue("@usuarioNombre", nombre);
                     command.Parameters.AddWithValue("@usuarioContrasenia", pass);
                     connection.Open();

                     using (SQLiteDataReader dataReader = command.ExecuteReader())
                     {
                         dataReader.Read();
                         usuarioID = Convert.ToInt32(dataReader["usuarioID"]);
                         connection.Close();
                    }
                 }
             }
            
            return usuarioID;
        }

        public int getUsuarioRol(int idUsuario)
        {
            int usuarioRol = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string sqlQuery = "SELECT usuarioRol FROM Usuarios WHERE usuarioID = @idUsuario;";

                    using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        connection.Open();

                        using (SQLiteDataReader dataReader = command.ExecuteReader())
                        {
                            dataReader.Read();
                            usuarioRol = Convert.ToInt32(dataReader["usuarioRol"]);
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;
            }

            return usuarioRol;
        }
    }
}

