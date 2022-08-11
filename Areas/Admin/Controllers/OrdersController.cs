using PagedList;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/Orders
        public ActionResult Index(int? page)
        {
            //hello ae
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 9;
            return View(db.Orders.OrderByDescending(x => x.CreatedTime).ToPagedList(pageNumber, pageSizeNumber));
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedTime,Status,Total,FullName,Email,Address,Phone")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.deliveryEmployeesId = new SelectList(db.DeliveryEmployees.ToList(), "Id", "FullName");

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int deliveryEmployeesId, int Id)
        {
            if (ModelState.IsValid)
            {
                var order = db.Orders.Find(Id);
                order.DeliveryEmployee = db.DeliveryEmployees.Find(deliveryEmployeesId);
                order.Status = OrderStatus.Shipping;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            order.Status = OrderStatus.Cancel;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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