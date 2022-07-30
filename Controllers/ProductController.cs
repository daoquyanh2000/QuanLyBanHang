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
            List<Product> products;
            if(ProductTypeId != null)
            {
                products = db.Products.Where(product => product.ProductTypeId == ProductTypeId).ToList();
            }
            else
            {
                products = db.Products.ToList();
            }
            return View(products);
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
    }
}