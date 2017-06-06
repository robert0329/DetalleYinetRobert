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

namespace DetalleCotizaciones.Controllers
{
    public class CotizacionesDetallesController : Controller
    {
        private CotizacionesDb db = new CotizacionesDb();

        // GET: CotizacionesDetalles
        public ActionResult Index()
        {
            return View(BLL.DetalleCotizacionesBLL.Listar());
        }

        // GET: CotizacionesDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalle cotizacionesDetalle = db.Cotice.Find(id);
            if (cotizacionesDetalle == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalle);
        }

        // GET: CotizacionesDetalles/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.cotizacion, "CotizacionId", "Descripcion");
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Descripcion");
            return View();
        }

        // POST: CotizacionesDetalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CotizacionId,ProductoId,Descripcion,Cantidad,Precio")] CotizacionesDetalle cotizacionesDetalle)
        {
            if (ModelState.IsValid)
            {
                BLL.DetalleCotizacionesBLL.Guardar(cotizacionesDetalle);
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.cotizacion, "CotizacionId", "Descripcion", cotizacionesDetalle.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Descripcion", cotizacionesDetalle.ProductoId);
            return View(cotizacionesDetalle);
        }
        public JsonResult Insertar(List<CotizacionesDetalle> deta)
        {
            bool resultado = BLL.DetalleCotizacionesBLL.Insertar(deta);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        // GET: CotizacionesDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalle cotizacionesDetalle = db.Cotice.Find(id);
            if (cotizacionesDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.cotizacion, "CotizacionId", "Descripcion", cotizacionesDetalle.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Descripcion", cotizacionesDetalle.ProductoId);
            return View(cotizacionesDetalle);
        }

        // POST: CotizacionesDetalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CotizacionId,ProductoId,Descripcion,Cantidad,Precio")] CotizacionesDetalle cotizacionesDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotizacionesDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.cotizacion, "CotizacionId", "Descripcion", cotizacionesDetalle.CotizacionId);
            ViewBag.ProductoId = new SelectList(db.productos, "ProductoId", "Descripcion", cotizacionesDetalle.ProductoId);
            return View(cotizacionesDetalle);
        }

        // GET: CotizacionesDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionesDetalle cotizacionesDetalle = db.Cotice.Find(id);
            if (cotizacionesDetalle == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionesDetalle);
        }

        // POST: CotizacionesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionesDetalle cotizacionesDetalle = db.Cotice.Find(id);
            db.Cotice.Remove(cotizacionesDetalle);
            db.SaveChanges();
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
