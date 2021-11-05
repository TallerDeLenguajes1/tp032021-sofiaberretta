using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Models
{
    public class RepositorioCadete
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioCadete(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cadete> getAllCadetes()
        {
            List<Cadete> listadoCadetes = new List<Cadete>();

            using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Cadetes WHERE activo = 1;";
                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    Cadete cadete = new Cadete()
                    {
                        Id = Convert.ToInt32(dataReader["cadeteID"]),
                        Nombre = dataReader["cadeteNombre"].ToString(),
                        Telefono = dataReader["cadeteTelefono"].ToString(),
                        Direccion = dataReader["cadeteDireccion"].ToString(),
                    };

                    listadoCadetes.Add(cadete);
                }

                conexion.Close();
            }

            return listadoCadetes;
        }


        public Cadete getCadeteById(int id)
        {
            Cadete cadeteBuscado = null;
            using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Cadetes WHERE cadeteID = @idCadete;";
                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                command.Parameters.AddWithValue("@idCadete", id);

                var dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    cadeteBuscado = new Cadete()
                    {
                        Id = Convert.ToInt32(dataReader["cadeteID"]),
                        Nombre = dataReader["cadeteNombre"].ToString(),
                        Telefono = dataReader["cadeteTelefono"].ToString(),
                        Direccion = dataReader["cadeteDireccion"].ToString(),
                    };
                }

                conexion.Close();
            }

            return cadeteBuscado;
        }


        public void guardarCadete(Cadete cadeteAGuardar)
        {
            try
            {
                string instruccion = @"INSERT INTO
                                        Cadetes (cadeteNombre, cadeteTelefono, cadeteDireccion)
                                        VALUES (@nombre, @telefono, @direccion)";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", cadeteAGuardar.Nombre);
                        command.Parameters.AddWithValue("@telefono", cadeteAGuardar.Telefono);
                        command.Parameters.AddWithValue("@direccion", cadeteAGuardar.Direccion);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

            } catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;
            }
        }

        public void modificarCadete(Cadete cadeteAModificar)
        {
            try
            {
                string instruccion = @"UPDATE Cadetes
                                        SET cadeteNombre = @nombre, cadeteTelefono = @telefono, cadeteDireccion = @direccion
                                        WHERE cadeteID = @cadeteID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", cadeteAModificar.Nombre);
                        command.Parameters.AddWithValue("@telefono", cadeteAModificar.Telefono);
                        command.Parameters.AddWithValue("@direccion", cadeteAModificar.Direccion);
                        command.Parameters.AddWithValue("@cadeteID", cadeteAModificar.Id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;
            }
        }

        public void borrarCadete(Cadete cadeteABorrar)
        {
            try
            {
                string instruccion = @"UPDATE Cadetes
                                        SET activo = @activo                                        
                                        WHERE cadeteID = @cadeteID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@activo", 0);
                        command.Parameters.AddWithValue("@cadeteID", cadeteABorrar.Id);
                        conexion.Open();
                        command.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                var mensaje = "Mensaje de error: " + ex.Message;
            }
        }
    }
}