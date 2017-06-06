using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }

        public virtual Productos product { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<CotizacionesDetalle> Detalle { get; set; } //Muchos

        public Cotizaciones()
        {
            this.Detalle = new HashSet<CotizacionesDetalle>();
        }

        public void AgregarDetalle(Productos producto, decimal cantidad)
        {
            this.Detalle.Add(new CotizacionesDetalle(producto.ProductoId, cantidad, producto.Precio, producto.Descripcion));
        }
    }
}