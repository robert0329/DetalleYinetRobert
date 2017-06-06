using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetalleCotizaciones.DAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DetalleCotizaciones.BLL
{
    public class CotizacionesBLL
    {
        //public static Cotizaciones Guardar(Cotizaciones Cot)
        //{
        //    Cotizaciones guardar = null;
        //    using (var repositorio = new Repositorio<Cotizaciones>())
        //    {
        //        return guardar = repositorio.Guardar(Cot);
        //    }
        //}
        //public static bool Mofidicar(Cotizaciones cotizacion)
        //{
        //    bool Mod = false;
        //    using (var repositorio = new Repositorio<Cotizaciones>())
        //    {
        //        return Mod = repositorio.Modificar(cotizacion);
        //    }
        //}
        //public static bool Eliminar(Cotizaciones cotizacion)
        //{
        //    bool Eli = false;
        //    using (var repositorio = new Repositorio<Cotizaciones>())
        //    {
        //        return Eli = repositorio.Eliminar(cotizacion);
        //    }
        //}
        //public static Cotizaciones Buscar(Expression<Func<Cotizaciones, bool>> tipo)
        //{
        //    Cotizaciones Result = null;

        //    using (var repositorio = new Repositorio<Cotizaciones>())
        //    {
        //        Result = repositorio.Buscar(tipo);

        //        if (Result != null)
        //            Result.Deta.Count();
        //    }
        //    return Result;
        //}
        public static bool Guardar(Cotizaciones nuevo)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    var c = Buscar(nuevo.ClienteId);
                    if (c == null)
                        conexion.cotizacion.Add(nuevo);
                    else
                        conexion.Entry(nuevo).State = EntityState.Modified;
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
        public static bool Eliminar(Cotizaciones existente)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    conexion.Entry(existente).State = EntityState.Deleted;
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
        public static Cotizaciones Buscar(int Id)
        {
            var cc = new Cotizaciones();
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    cc = conexion.cotizacion.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return cc;
        }

        public static List<Cotizaciones> GetLista()
        {
            var lista = new List<Cotizaciones>();
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    lista = conexion.cotizacion.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Cotizaciones> GetListaId(int Id)
        {
            List<Cotizaciones> list = new List<Cotizaciones>();

            var db = new CotizacionesDb();

            list = db.cotizacion.Where(p => p.CotizacionId == Id).ToList();

            return list;
        }
    }
}