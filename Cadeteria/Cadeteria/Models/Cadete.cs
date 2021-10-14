using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listadoPedidos;
        private int cantPedidosPagados;

        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ListadoPedidos = new List<Pedidos>();
            CantPedidosPagados = 0;
        }

        public Cadete() 
        { 
        
        }

        public int Pago()
        {
            int total = 0;
            foreach (var item in listadoPedidos)
            {
                if (item.Estado == "Entregado")
                {
                    total += 100;
                }
            }
            return total;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public int CantPedidosPagados { get => cantPedidosPagados; set => cantPedidosPagados = value; }
    }
}
