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

                string instruccionSQL = "SELECT * FROM Cadetes;";
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

        public void guardarCadete(Cadete cadeteAGuardar)
        {
            
        }

        public void modificarCadete(Cadete cadeteAModificar)
        {
            
        }

        public void borrarrCadete(Cadete cadeteABorrar)
        {
        
        }
    }
}