using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DetalleCotizaciones.Models
{
    public class Cotizaciones
    {
        [Key]
        public int CotizacionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Cliente { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Currency)]
        public double Monto { get; set; }

        //public virtual Productos product { get; set; }
        //public virtual Clientes Cliente { get; set; }
        //public virtual ICollection<CotizacionesDetalle> Detalle { get; set; }

        public Cotizaciones()
        {
            //this.Detalle = new HashSet<CotizacionesDetalle>();
        }

        //public void AgregarDetalle(Productos producto, decimal cantidad)
        //{
        //    this.Detalle.Add(new CotizacionesDetalle(producto.ProductoId, cantidad, producto.Precio, producto.Descripcion));
        //}
    }
}