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
        public static bool Guardar(CotizacionesDetalle detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    conexion.Cotice.Add(detalle);
                    conexion.SaveChanges();
                    resultado = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return resultado;
        }
        public static List<CotizacionesDetalle> Listar()
        {
            List<CotizacionesDetalle> listado = null;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    listado = conexion.Cotice.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return listado;
        }
        public static bool Insertar(List<CotizacionesDetalle> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (CotizacionesDetalle detail in detalles)
                {
                    resultado = Guardar(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}