using MoreLinq;
using PagedList;
using QuanLyBanHang.Areas.Admin.Models;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{
    public class ProductController : Controller
    {
        public const int PageSize = 9;
        private StoreContext db = new StoreContext();

        // GET: Product
        public ActionResult Index(int? ProductTypeId, int Page = 1, string keyword = null)
        {
            keyword = keyword ?? "";
            var productTypes = db.ProductTypes.ToList().Where(x => x.Status == ProductTypeStatus.Active);
            ViewBag.productTypes = productTypes;
            if (ProductTypeId != null)
            {
                var products = from p in db.Products.ToList()
                               where p.ProductTypeId == ProductTypeId
                           && p.Status == ProductStatus.Active
                               select p;
                return View(products.ToPagedList(Page, PageSize));
            }
            else
            {
                var products = from p in db.Products.ToList()
                               where p.Status == ProductStatus.Active
                               && (p.Title.ToLower().Contains(keyword.ToLower())
                               || p.Code.ToLower().Contains(keyword.ToLower()))
                               select p;
                return View(products.ToPagedList(Page, PageSize));
            }
        }
        public ActionResult FeaturedProduct()
        {
            var listProduct = new List<FeaturedProduct>();
            var listType = db.ProductTypes.Where(x => x.Status == ProductTypeStatus.Active).ToList();
            foreach(var type in listType)
            {
                var featuredProduct = new FeaturedProduct();
                featuredProduct.TypeName = type.Name;
                featuredProduct.Id = type.ID;
                featuredProduct.Products = db.Products.Where(x => x.ProductTypeId == type.ID&& x.Status==ProductStatus.Active).ToList();
                listProduct.Add(featuredProduct);
            }
            return PartialView(listProduct);
        }
        public ActionResult SubListProduct()
        {
            var listListProduct = new List<SubListProduct>();

            foreach (var category in db.Categories.Where(x=>x.Status==CategoryStatus.Active).ToList())
            {
                var subListProduct = new SubListProduct();
                subListProduct.CategoryName = category.Name;
                subListProduct.Products = category.Products.Batch(3).ToList();
                listListProduct.Add(subListProduct);
            };

            return PartialView(listListProduct);
        }

        public ActionResult ProductSidebar()
        {
            var productTypes = db.ProductTypes.ToList().Where(x => x.Status == ProductTypeStatus.Active);
            return PartialView(productTypes);
        }

        public ActionResult SaleProducts()
        {
            var saleProducts = db.Products.Where(p => p.Discount > 0 && p.Status == ProductStatus.Active && p.ProductType.Status == ProductTypeStatus.Active).ToList();
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