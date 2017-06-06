using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int LimiteCredito { get; set; }
        public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }

        public Clientes()
        {
            this.Cotizaciones = new HashSet<Cotizaciones>();

        }
    }
}