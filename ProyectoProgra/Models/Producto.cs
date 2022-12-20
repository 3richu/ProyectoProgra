using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Carros = new HashSet<Carro>();
            ProdRecs = new HashSet<ProdRec>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double Precio { get; set; }
        public int Inventario { get; set; }

        public virtual ICollection<Carro> Carros { get; set; }
        public virtual ICollection<ProdRec> ProdRecs { get; set; }
    }
}
