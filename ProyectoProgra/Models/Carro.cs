using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models
{
    public partial class Carro
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
