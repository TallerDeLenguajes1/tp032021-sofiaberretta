using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Models
{
    public class RepositorioPedidoSQLite : IPedidoDB
    {
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioPedidoSQLite(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pedidos> getAllPedidos()
        {
            List<Pedidos> listadoPedidos = new List<Pedidos>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Pedidos INNER JOIN Clientes USING(clienteId) WHERE Pedidos.activo = 1 ;";

                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Pedidos pedido = new Pedidos()
                    {
                        NumeroPedido = Convert.ToInt32(dataReader["pedidoID"]),
                        Observaciones = dataReader["pedidoObs"].ToString(),
                        Estado = dataReader["pedidoEstado"].ToString(),
                    };

                    Cliente cliente = new Cliente()
                    {
                        Id = Convert.ToInt32(dataReader["clienteID"].ToString()),
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

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string instruccionSQL = "SELECT * FROM Pedidos INNER JOIN Clientes USING(clienteId) WHERE pedidoID = @idPedido;";

                SQLiteCommand command = new SQLiteCommand(instruccionSQL, conexion);

                command.Parameters.AddWithValue("@idPedido", id);

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
                        Id = Convert.ToInt32(dataReader["clienteID"].ToString()),
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


        public void guardarPedido(Pedidos pedidoAGuardar)
        {
            try
            {
                string instruccion = @"INSERT INTO 
                                        Pedidos (pedidoObs, clienteId, pedidoEstado) 
                                        VALUES (@obs, @clienteId, @estado)";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@obs", pedidoAGuardar.Observaciones);
                        command.Parameters.AddWithValue("@clienteId", pedidoAGuardar.Cliente.Id);
                        command.Parameters.AddWithValue("@estado", pedidoAGuardar.Estado);
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

        public void modificarPedido(Pedidos pedidoAModificar)
        {
            try
            {
                string instruccion = @"UPDATE Pedidos 
                                        SET pedidoObs = @obs, pedidoEstado = @estado 
                                        WHERE pedidoID = @pedidoID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@pedidoObs", pedidoAModificar.Observaciones);
                        command.Parameters.AddWithValue("@pedidoEstado", pedidoAModificar.Estado);
                        command.Parameters.AddWithValue("@pedidoID", pedidoAModificar.NumeroPedido);
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

        public void borrarPedido(Pedidos pedidoABorrar)
        {
            try
            {
                string instruccion = @"UPDATE Pedidos
                                        SET activo = @activo                                        
                                        WHERE pedidoID = @pedidoID";

                using (var conexion = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(instruccion, conexion))
                    {
                        command.Parameters.AddWithValue("@activo", 0);
                        command.Parameters.AddWithValue("@cadeteID", pedidoABorrar.NumeroPedido);
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