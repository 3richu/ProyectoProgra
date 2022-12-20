using System;
using System.Collections.Generic;

namespace ProyectoProgra.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Carros = new HashSet<Carro>();
            Recibos = new HashSet<Recibo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public virtual ICollection<Carro> Carros { get; set; }
        public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
