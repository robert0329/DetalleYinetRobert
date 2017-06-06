using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DetalleCotizaciones.DAL
{
    //public class Repositorio<Tentity> : IRepository<Tentity> where Tentity : class
    //{
        //CotizacionesDb Db = null;
        //public Repositorio()
        //{
        //    Db = new CotizacionesDb();
        //}
        //private DbSet<Tentity> EntitySet
        //{
        //    get { return Db.Set<Tentity>(); }
        //}
        //public Tentity Guardar(Tentity Eentity)
        //{
        //    Tentity resultado = null;
        //    try
        //    {
        //        EntitySet.Add(Eentity);
        //        Db.SaveChanges();
        //        resultado = Eentity;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return resultado;
        //}
        //public bool Modificar(Tentity Eentidad)
        //{
        //    bool resultado = false;
        //    try
        //    {
        //        EntitySet.Attach(Eentidad);
        //        Db.Entry<Tentity>(Eentidad).State = EntityState.Modified;
        //        resultado = Db.SaveChanges() > 0;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return resultado;
        //}
        //public Tentity Buscar(Expression<Func<Tentity, bool>> criterioBusqueda)
        //{
        //    Tentity Resultado = null;

        //    try
        //    {
        //        Resultado = EntitySet.FirstOrDefault(criterioBusqueda);
        //    }
        //    catch { }

        //    return Resultado;
        //}

        //public bool Eliminar(Tentity laEntidad)
        //{
        //    bool Resultado = false;

        //    try
        //    {
        //        EntitySet.Attach(laEntidad);
        //        EntitySet.Remove(laEntidad);
        //        Resultado = Db.SaveChanges() > 0;
        //    }
        //    catch { }

        //    return Resultado;
        //}

        //public List<Tentity> Lista(Expression<Func<Tentity, bool>> criterioBusqueda)
        //{
        //    List<Tentity> Resultado = null;
        //    try
        //    {
        //        Resultado = EntitySet.Where(criterioBusqueda).ToList();
        //    }
        //    catch { }

        //    return Resultado;
        //}

        //public List<Tentity> ListaTodo()
        //{
        //    using (var Conec = new CotizacionesDb())
        //    {
        //        try
        //        {
        //            return EntitySet.ToList();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }

        //    return null;
        //}

        //public void Dispose()
        //{
        //    if (Db != null)
        //        Db.Dispose();
        //}

    //}
}