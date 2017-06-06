using DetalleCotizaciones.DAL;
using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DetalleCotizaciones.BLL
{
    public class DetalleCotizacionesBLL
    {
        public static bool Guardar(CotizacionesDetalle deta)
        {
            bool retorno = false;
            try
            {
                using (var db = new CotizacionesDb())
                {
                    db.Cotice.Add(deta);
                    db.SaveChanges();
                }
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
    }
}