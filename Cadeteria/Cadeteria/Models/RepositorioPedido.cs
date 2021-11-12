using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Models
{
    public class RepositorioPedido
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioPedido(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pedidos> getAllPedidos()
        {
            List<Pedidos> listadoPedidos = new List<Pedidos>();

            using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Pedidos WHERE activo = 1" +
                                        "INNER JOIN Clientes USING(clienteId);";

                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while(dataReader.Read())
                {
                    Pedidos pedido = new Pedidos()
                    {
                        NumeroPedido = Convert.ToInt32(dataReader["pedidoID"]),
                        Observaciones = dataReader["pedidoObs"].ToString(),
                        Estado = dataReader["pedidoEstado"].ToString(),
                    };

                    Cliente cliente = new Cliente()
                    {
                        Id = dataReader["clienteID"].ToString(),
                        Nombre = dataReader["clienteNombre"].ToString(),
                        Direccion = dataReader["clienteDireccion"].ToString(),
                        Telefono = dataReader["clienteTelefono"].ToString()
                    };

                    pedido.Cliente = cliente;

                    listadoPedidos.Add(pedido);
                }

                conexion.Close();
            }

            return listadoPedidos;
        }


        public Pedidos getPedidoById(int id)
        {
            Pedidos pedidoBuscado = null;

            using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Pedidos WHERE pedidoID = @idPedido" +
                                        "INNER JOIN Clientes USING(clienteId);";

                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    pedidoBuscado = new Pedidos()
                    {
                        NumeroPedido = Convert.ToInt32(dataReader["pedidoID"]),
                        Observaciones = dataReader["pedidoObs"].ToString(),
                        Estado = dataReader["pedidoEstado"].ToString(),
                    };

                    Cliente cliente = new Cliente()
                    {
                        Id = dataReader["clienteID"].ToString(),
                        Nombre = dataReader["clienteNombre"].ToString(),
                        Direccion = dataReader["clienteDireccion"].ToString(),
                        Telefono = dataReader["clienteTelefono"].ToString()
                    };

                    pedidoBuscado.Cliente = cliente;
                }

                conexion.Close();
            }

            return pedidoBuscado;
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