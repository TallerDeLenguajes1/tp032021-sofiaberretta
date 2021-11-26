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
                                   "VALUES (@usuarioNombre, @usuarioPassword);";

                using (SQLiteCommand command = new SQLiteCommand(sqlQuery, conexion))
                {
                    command.Parameters.AddWithValue("@usuarioNombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@usuarioPassword", usuario.Password);

                    conexion.Open();
                    command.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            
        }

        public int getUsuarioById(string nombre, string pass)
        {
            int usuarioID = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                 string sqlQuery = "SELECT usuarioID FROM Usuarios WHERE usuarioNombre = @usuarioNombre AND usuarioPassword = @usuarioPassword;";

                 using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
                 {
                     command.Parameters.AddWithValue("@usuarioNombre", nombre);
                     command.Parameters.AddWithValue("@usuarioPassword", pass);
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
    }
}

