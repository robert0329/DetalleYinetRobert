using DetalleCotizaciones.DAL;
using DetalleCotizaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DetalleCotizaciones.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}