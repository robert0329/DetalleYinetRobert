using DetalleCotizaciones.DAL;
using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DetalleCotizaciones.BLL
{
    public class ClientesBLL
    {
        //public static Clientes Guardar(Clientes cliente)
        //{
        //    Clientes creado = null;
        //    using (var repositorio = new Repositorio<Clientes>())
        //    {
        //        return creado = repositorio.Guardar(cliente);
        //    }
        //}

        //public static List<Clientes> Lista(Expression<Func<Clientes, bool>> CriterioBusqueda)
        //{
        //    List<Clientes> buscado = null;
        //    using (var repositorio = new Repositorio<Clientes>())
        //    {
        //        return buscado = repositorio.Lista(CriterioBusqueda).ToList();
        //    }
        //}

        //public static List<Clientes> ListaTodo()
        //{
        //    List<Clientes> list = null;
        //    using (var db = new Repositorio<Clientes>())
        //    {
        //       return list = db.ListaTodo();               
        //    }
        //}
        public static bool Insertar(Clientes nuevo)
        {
            bool resultado = false;
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    var c = Buscar(nuevo.ClienteId);
                    if (c == null)
                        conexion.Clientes.Add(nuevo);
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
        public static bool Eliminar(Clientes existente)
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
        public static Clientes Buscar(int Id)
        {
            var cc = new Clientes();
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    cc = conexion.Clientes.Find(Id);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return cc;
        }
        public static Clientes Buscar(string Nombre)
        {
            var Cliente = new Clientes();
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    Cliente = conexion.Clientes.Where(c => c.Nombres.Equals(Nombre)).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Cliente;
        }
        public static List<Clientes> GetLista()
        {
            var lista = new List<Clientes>();
            using (var conexion = new CotizacionesDb())
            {
                try
                {
                    lista = conexion.Clientes.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return lista;

        }
        public static List<Clientes> GetListaId(int Id)
        {
            List<Clientes> list = new List<Clientes>();

            var db = new CotizacionesDb();

            list = db.Clientes.Where(p => p.ClienteId == Id).ToList();

            return list;

        }
        public static List<Clientes> GetListaNombre(string m)
        {
            List<Clientes> lista = new List<Clientes>();

            var db = new CotizacionesDb();

            lista = db.Clientes.Where(p => string.Equals(p.Nombres, m)).ToList();

            return lista;

        }
    }
}