using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Models
{
    public class RepositorioClienteSQLite : IClienteDB
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioClienteSQLite(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cliente> getAllClientes()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Clientes WHERE activo = 1";
                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        Id = Convert.ToInt32(dataReader["clienteID"]),
                        Nombre = dataReader["clienteNombre"].ToString(),
                        Telefono = dataReader["clienteTelefono"].ToString(),
                        Direccion = dataReader["clienteDireccion"].ToString(),
                    };

                    listadoClientes.Add(cliente);
                }

                conexion.Close();
            }

            return listadoClientes;
        }


        public int getLastIDCliente()
        {
            int idBuscado = 0;
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT clienteID FROM Clientes WHERE activo = 1 ORDER BY clienteID DESC LIMIT 1;";
                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    idBuscado = Convert.ToInt32(dataReader["clienteID"]);
                }

                conexion.Close();
            }

            return idBuscado;
        }


        public void guardarCliente(Cliente clienteAGuardar)
        {
            try
            {
                string instruccion = @"INSERT INTO
                                        Clientes (clienteNombre, clienteDireccion, clienteTelefono)
                                        VALUES (@nombre, @direccion, @telefono)";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", clienteAGuardar.Nombre);
                        command.Parameters.AddWithValue("@direccion", clienteAGuardar.Direccion);
                        command.Parameters.AddWithValue("@telefono", clienteAGuardar.Telefono);
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

        public void modificarCliente(Cliente clienteAModificar)
        {
            try
            {
                string instruccion = @"UPDATE Clientes
                                        SET clienteNombre = @nombre, clienteDireccion = @direccion, clienteTelefono = @telefono
                                        WHERE clienteID = @clienteID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@nombre", clienteAModificar.Nombre);
                        command.Parameters.AddWithValue("@direccion", clienteAModificar.Direccion);
                        command.Parameters.AddWithValue("@telefono", clienteAModificar.Telefono);
                        command.Parameters.AddWithValue("@cadeteID", clienteAModificar.Id);
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

        public void borrarCliente(Cliente clienteABorrar)
        {
            try
            {
                string instruccion = @"UPDATE Cliente
                                        SET activo = @activo                                        
                                        WHERE clienteID = @clienteID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@activo", 0);
                        command.Parameters.AddWithValue("@cadeteID", clienteABorrar.Id);
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