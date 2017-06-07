using DetalleCotizaciones.DAL;
using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DetalleCotizaciones.BLL
{
    public class DetalleCotizacionesBLL
    {
        public static bool Guardar(CotizacionDetalles detalle)
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
        public static CotizacionDetalles Buscar(int? detalleCotizacionId)
        {
            CotizacionDetalles detalle = null;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    detalle = conexion.Cotice.Find(detalleCotizacionId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return detalle;
        }
        public static bool Modificar(CotizacionDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Modified;
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
        public static bool Eliminar(CotizacionDetalles detalle)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    conexion.Entry(detalle).State = EntityState.Deleted;
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
        public static List<CotizacionDetalles> Listar()
        {
            List<CotizacionDetalles> listado = null;
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

        public static bool Guardar(List<CotizacionDetalles> detalles)
        {
            bool resultado = false;
            try
            {
                foreach (CotizacionDetalles detail in detalles)
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