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
        public int Id { get; set; }
        public int CotizacionId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }


        public virtual Productos Producto { get; set; }
        public virtual Cotizaciones Cotizaciones { get; set; } //Uno

        public CotizacionesDetalle()
        {
            Producto = new Productos();
        }

        public CotizacionesDetalle(int productoId, decimal cantidad, decimal precio, string descripcion)
        {
            this.Descripcion = descripcion;
            this.ProductoId = productoId;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

    }
}