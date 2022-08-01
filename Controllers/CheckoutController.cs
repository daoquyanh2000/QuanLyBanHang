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
        public ActionResult Index(Customer  customer)
        {
            var listItem = (List<CartItem>)Session[CartSession];
            var total = listItem.Sum(x => x.Quantity * x.Price);
            var orderDetails = new List<OrderDetail>();

            var order = new Order()
            {
                CreatedTime = DateTime.Now,
                Status = OrderStatus.Pending,
                Total = (long)total,
                Customer=customer,
            };
            foreach (var item in listItem)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Quantity,
                    PricePerUnit = (long)item.Price,
                    Money = total,
                };
                orderDetails.Add(orderDetail);
            };
            order.OrderDetails = orderDetails;

            db.Orders.Add(order);

            db.SaveChanges();


            return View();
        }
    }
}