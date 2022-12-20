using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models
{
    public partial class Recibo
    {
        public Recibo()
        {
            ProdRecs = new HashSet<ProdRec>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double? Total { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ProdRec> ProdRecs { get; set; }
    }
}
