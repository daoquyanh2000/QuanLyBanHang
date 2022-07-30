using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.DB;
namespace QuanLyBanHang.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private StoreContext db = new StoreContext();
        // GET: Cart
        public ActionResult Index() 
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult PartialCart()
        {
            var cart = Session[CartSession];
            var partialCart = new PartialCart();
            if(cart != null) {
                var list = (List<CartItem>)cart;
                var totalMoney = list.Sum(item => item.Quantity * item.Price);
                var totalItem = list.Count;
                partialCart.TotalItem = totalItem;
                partialCart.TotalMoney = totalMoney;
            }
            else
            {
                partialCart.TotalMoney = 0;
                partialCart.TotalItem = 0;
            }
            return PartialView(partialCart);
        }
        public ActionResult AddItem(int ProductId,int quantity)
        {
            var product = db.Products.Find(ProductId);
            var cart = Session[CartSession];
            if( cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.Id == ProductId))
                {
                    foreach (var item in list)
                    {

                        if (item.Product.Id == ProductId)
                        {
                            item.Quantity += quantity;
                            item.Price = product.Price*(1 - (product.Discount) * (1 / 100));
                        }
                        
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    item.Price = product.Price * (1 - (product.Discount) * (1 / 100));
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                item.Price = product.Price * (1 - (product.Discount) * (1 / 100));
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return Redirect("Index");
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