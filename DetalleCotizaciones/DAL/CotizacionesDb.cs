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
        public DbSet<Cotizaciones> cotizacion { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<CotizacionesDetalle> Cotice { get; set; }  
    }
}