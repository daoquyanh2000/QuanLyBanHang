using QuanLyBanHang.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using QuanLyBanHang.DB.Entities;
namespace QuanLyBanHang.Controllers
{
    public class ProductController : Controller
    {
        public const int PageSize = 9;
        private StoreContext db = new StoreContext();

        // GET: Product
        public ActionResult Index(int? ProductTypeId,int PageNumber = 1, string keyword=null )
        {
            keyword=keyword ?? "";
            var productTypes = db.ProductTypes.ToList().Where(x => x.Status == ProductTypeStatus.Active);
            ViewBag.productTypes = productTypes;
            if (ProductTypeId != null)
            {
                var products = from p in db.Products.ToList()
                               where p.ProductTypeId == ProductTypeId
                           && p.Status == ProductStatus.Active
                           select p;
                return View(products.ToPagedList(PageNumber,PageSize));
            }
            else
            {
                var products = from p in db.Products.ToList()
                               where p.Status == ProductStatus.Active
                               && (p.Title.ToLower().Contains(keyword.ToLower())
                               || p.Code.ToLower().Contains(keyword.ToLower()))
                               select p;
                return View(products.ToPagedList(PageNumber, PageSize));
            }
  
        }

        public ActionResult ProductSidebar()
        {
            var productTypes = db.ProductTypes.ToList().Where(x=>x.Status==ProductTypeStatus.Active);
            return PartialView(productTypes);
        }
        public ActionResult SaleProducts()
        {
            var saleProducts = db.Products.Where(p => p.Discount > 0 && p.Status == ProductStatus.Active && p.ProductType.Status== ProductTypeStatus.Active).ToList();
            return PartialView(saleProducts);
        }
        public ActionResult Detail(int ProductId)
        {
            var product = db.Products.Find(ProductId);
            return View(product);
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