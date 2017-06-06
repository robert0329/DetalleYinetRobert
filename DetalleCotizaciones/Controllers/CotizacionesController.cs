using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DetalleCotizaciones.DAL;
using DetalleCotizaciones.Models;
using DetalleCotizaciones.BLL;

namespace DetalleCotizaciones.Controllers
{
    public class CotizacionesController : Controller
    {
        private CotizacionesDb db = new CotizacionesDb();

        public JsonResult getProductCategories()
        {
            List<Category> categories = new List<Category>();
            using (CotizacionesDb dc = new CotizacionesDb())
            {
                categories = dc.Categories.OrderBy(a => a.CategoryName).ToList();
            }
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryID)
        {
            List<Productos> products = new List<Productos>();
            using (CotizacionesDb dc = new CotizacionesDb())
            {
                products = dc.productos.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.Descripcion).ToList();
            }
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Index()
        {
            var cotizaciones = db.cotizacion.Include(c => c.Cliente);
            //cotizaciones..Include(c => c.Descripcion);
            return View(cotizaciones.ToList());
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cotizaciones cotizaciones = db.cotizacion.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres");
            ViewBag.Descripcion = new SelectList(db.productos, "ProductoId", "Descripcion");
            return View();
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,Fecha,ClienteId,Monto,Descripcion,ProductoId")] Cotizaciones cotizaciones)
        {
            var Cot = new Cotizaciones();
            if (ModelState.IsValid)
            {
                //var cot = new Cotizaciones()
                //{
                //    CotizacionId = cotizaciones.CotizacionId,
                //    Fecha = DateTime.Now,
                //    Monto = cotizaciones.Monto
                //};

                cotizaciones.AgregarDetalle(new Productos()
                {
                    ProductoId = 10,
                    Descripcion = cotizaciones.Descripcion,
                    Precio = 1000
                }, 1000
                );
                CotizacionesBLL.Guardar(cotizaciones);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", cotizaciones.ClienteId);
            ViewBag.Descripcion = new SelectList(db.productos, "ProductoId", "Descripcion", cotizaciones.Descripcion);
            return View(cotizaciones);
        }

        //// GET: Cotizaciones/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    ////Cotizaciones cotizaciones = CotizacionesBLL.Buscar(p => p.CotizacionId == id);
        //    //if (cotizaciones == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", cotizaciones.ClienteId);
        //    //return View(cotizaciones);
        //}

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Fecha,ClienteId,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                //CotizacionesBLL.Mofidicar(cotizaciones);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nombres", cotizaciones.ClienteId);
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = db.cotizacion.Find(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CotizacionesBLL.Eliminar(CotizacionesBLL.Buscar(p => p.CotizacionId == id));
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
