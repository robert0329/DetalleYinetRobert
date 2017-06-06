using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int CategoryID { get; set; }
        public string Descripcion { get; set; }
        public string Medida { get; set; }
        public bool Itbis { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<CotizacionesDetalle> CotizacionesDetalle { get; set; }
        public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }

        public Productos()
        {
            this.CotizacionesDetalle = new HashSet<CotizacionesDetalle>();
            this.Cotizaciones = new HashSet<Cotizaciones>();
        }

        public override string ToString()
        {
            return string.Format("ProductoId: {0}, Descripción: {1}", this.ProductoId, this.Descripcion);
        }
        
        
    }
}