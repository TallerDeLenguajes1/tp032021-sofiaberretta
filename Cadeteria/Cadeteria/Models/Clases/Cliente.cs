using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cliente(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }
        public Cliente(string nombre, string direccion, string telefono)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Cliente()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
