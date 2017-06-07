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
        public ActionResult Index()
        {
            return View(BLL.DetalleCotizacionesBLL.Listar());
        }        
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
        public ActionResult Create()
        {
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente");
            return View();
        }     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionDetalleId,CotizacionId,ProductoId,Produto,Cantidad,SubTotal")] CotizacionDetalles cotizacionDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.DetalleCotizacionesBLL.Guardar(cotizacionDetalles);
                return RedirectToAction("Index");
            }

            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }
        public JsonResult Save(List<CotizacionDetalles> detalles)
        {
            bool resultado = BLL.DetalleCotizacionesBLL.Save(detalles);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }    
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionDetalleId,CotizacionId,ProductoId,Producto,Cantidad,SubTotal")] CotizacionDetalles cotizacionDetalles)
        {
            if (ModelState.IsValid)
            {
                BLL.DetalleCotizacionesBLL.Modificar(cotizacionDetalles);
                return RedirectToAction("Index");
            }
            ViewBag.CotizacionId = new SelectList(db.Cotizacion, "CotizacionId", "Cliente", cotizacionDetalles.CotizacionId);
            return View(cotizacionDetalles);
        }       
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
