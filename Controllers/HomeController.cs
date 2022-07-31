using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            var categories = db.Categories.ToList().Where(x => x.Status == CategoryStatus.Active);
            ViewBag.categories = categories;
            var productTypes =db.ProductTypes.ToList();
            return View(productTypes);
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