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
    public class CotizacionDetallesController : Controller
    {
        private CotizacionesDb db = new CotizacionesDb();

        // GET: CotizacionDetalles
        public ActionResult Index()
        {
            return View(BLL.DetalleCotizacionesBLL.Listar());
        }

        // GET: CotizacionDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalles cotizacionDetalles = BLL.DetalleCotizacionesBLL.Buscar(id);
            if (cotizacionDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDetalles);
        }

        // GET: CotizacionDetalles/Create
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente");
            return View();
        }

        // POST: CotizacionDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionDetalleId,CotizacionId,ArticuloId,Articulo,Cantidad,PrecXund,SubTotal")] CotizacionDetalles cotizacionDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.DetalleCotizacionesBLL.Guardar(cotizacionDetalles);
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }

        //[HttpPost]
        public JsonResult Guardar(List<CotizacionDetalles> detalles)
        {
            bool resultado = BLL.DetalleCotizacionesBLL.Guardar(detalles);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // GET: CotizacionDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalles cotizacionDetalles = BLL.DetalleCotizacionesBLL.Buscar(id);
            if (cotizacionDetalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }

        // POST: CotizacionDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionDetalleId,CotizacionId,ArticuloId,Articulo,Cantidad,PrecXund,SubTotal")] CotizacionDetalles cotizacionDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.DetalleCotizacionesBLL.Modificar(cotizacionDetalles);
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }

        // GET: CotizacionDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotizacionDetalles cotizacionDetalles = BLL.DetalleCotizacionesBLL.Buscar(id);
            if (cotizacionDetalles == null)
            {
                return HttpNotFound();
            }
            return View(cotizacionDetalles);
        }

        // POST: CotizacionDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CotizacionDetalles cotizacionDetalles = BLL.DetalleCotizacionesBLL.Buscar(id);
            BLL.DetalleCotizacionesBLL.Eliminar(cotizacionDetalles);
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
