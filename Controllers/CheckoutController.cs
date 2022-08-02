using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Controllers
{

    public class CheckoutController : Controller
    {
        private const string CartSession = "CartSession";
        private StoreContext db = new StoreContext();

        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Order order,Customer customer)
        {
            if (ModelState.IsValid) 
            {
                var listItem = (List<CartItem>)Session[CartSession];
                var total = listItem.Sum(x => x.Quantity * x.Price);
                var orderDetails = new List<OrderDetail>();
                foreach (var item in listItem)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Quantity = item.Quantity,
                        PricePerUnit = (long)item.Price,
                        Discount = item.Product.Discount,
                        Money = item.Quantity * item.Price,
                        ProductId = item.Product.Id,
                    };
                    orderDetails.Add(orderDetail);
                };
                order.Total = (long)total;
                order.CreatedTime = DateTime.Now;
                order.OrderDetails = orderDetails;

                db.Orders.Add(order);
                db.SaveChanges();
                Session[CartSession] = new List<CartItem>();
                return Json(new{status=true}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(customer);
            }
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