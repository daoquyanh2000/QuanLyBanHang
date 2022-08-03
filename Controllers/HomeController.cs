using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            var productTypes = db.ProductTypes.ToList().Where(x => x.Status == ProductTypeStatus.Active);
            return View(productTypes);
        }

        public ActionResult SearchBar()
        {
            var categories = db.ProductTypes.Where(x => x.Status == ProductTypeStatus.Active).ToList();

            return PartialView(categories);
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