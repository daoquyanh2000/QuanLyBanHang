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
        public ActionResult Index(int? ProductTypeId, int PageNumber = 1)
        {
            if(ProductTypeId != null)
            {
                return View(db.Products.Where(product => product.ProductTypeId == ProductTypeId && product.Discount == 0).ToList().ToPagedList(PageNumber,PageSize));
            }
            else
            {
                var list = db.Products.ToList().ToPagedList(PageNumber, PageSize);
                return View(list);
            }
        }

        public ActionResult ProductSidebar()
        {
            var productTypes = db.ProductTypes.ToList();
            return PartialView(productTypes);
        }
        public ActionResult ProductList(int ProductTypeId, int PageNumber = 1)
        {
            return View();
        }
        public ActionResult SaleProducts()
        {
            var saleProducts = db.Products.Where(p => p.Discount > 0 && p.Status == ProductStatus.SecondValue).ToList();
            return PartialView(saleProducts);
        }
        public ActionResult Detail(int ProductId)
        {
            var product = db.Products.Find(ProductId);
            return View(product);
        }
    }
}