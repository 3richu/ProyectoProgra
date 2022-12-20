using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models
{
    public partial class ProdRec
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdRecibo { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Recibo IdReciboNavigation { get; set; } = null!;
    }
}
