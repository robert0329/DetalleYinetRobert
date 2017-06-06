using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.Models
{
    public class CotizacionesDetalle
    {
        [Key]
        public int DetalleCotizacionId { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal{ get; set; }

        public CotizacionesDetalle()
        {

        }
    }
}