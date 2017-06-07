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
    public class CotizacionesController : Controller
    {
        private CotizacionesDb db = new CotizacionesDb();

        // GET: Cotizaciones
        public ActionResult Index()
        {
            return View(BLL.CotizacionesBLL.Listar());
        }

        // GET: Cotizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Create
        public ActionResult Create()
        {
            ViewBag.Detail = new List<CotizacionDetalles>();
            return View();
        }

        // POST: Cotizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CotizacionId,Cliente,Fecha,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionesBLL.Guardar(cotizaciones);
                return RedirectToAction("Index");
            }

            return View(cotizaciones);
        }

        public JsonResult Guardar(Cotizaciones cotizacion)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                if (BLL.CotizacionesBLL.Guardar(cotizacion))
                {
                    id = cotizacion.CotizacionId;
                }
            }
            else
            {
                id = +1;
            }
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        // GET: Cotizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            if (cotizaciones == null)
            {
                return HttpNotFound();
            }
            return View(cotizaciones);
        }

        // POST: Cotizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CotizacionId,Cliente,Fecha,Monto")] Cotizaciones cotizaciones)
        {
            if (ModelState.IsValid)
            {
                BLL.CotizacionesBLL.Modificar(cotizaciones);
                return RedirectToAction("Index");
            }
            return View(cotizaciones);
        }

        // GET: Cotizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
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
            Cotizaciones cotizaciones = BLL.CotizacionesBLL.Buscar(id);
            BLL.CotizacionesBLL.Eliminar(cotizaciones);
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
