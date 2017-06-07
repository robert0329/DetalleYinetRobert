using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.DAL
{
    public class CotizacionesDb : DbContext
    {
        public CotizacionesDb() : base("ConStr")
        {

        }
        public DbSet<Cotizaciones> Cotizacion { get; set; }
        public DbSet<CotizacionDetalles> Cotice { get; set; }  
    }
}