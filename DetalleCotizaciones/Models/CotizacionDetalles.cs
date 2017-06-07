using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.Models
{
    public class CotizacionDetalles
    {
        [Key]
        public int CotizacionDetalleId { get; set; }

        public int CotizacionId { get; set; }

        public int ArticuloId { get; set; }

        public string Articulo { get; set; }

        public int Cantidad { get; set; }

        public double PrecXund { get; set; }

        public double SubTotal { get; set; }

        public CotizacionDetalles()
        {

        }
    }
}