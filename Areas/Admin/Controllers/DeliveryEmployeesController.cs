using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class DeliveryEmployeesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/DeliveryEmployees
        public ActionResult Index()
        {
            return View(db.DeliveryEmployees.ToList());
        }

        // GET: Admin/DeliveryEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEmployee deliveryEmployee = db.DeliveryEmployees.Find(id);
            if (deliveryEmployee == null)
            {
                return HttpNotFound();
            }
            return View(deliveryEmployee);
        }

        // GET: Admin/DeliveryEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeliveryEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Status")] DeliveryEmployee deliveryEmployee)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryEmployees.Add(deliveryEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryEmployee);
        }

        // GET: Admin/DeliveryEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEmployee deliveryEmployee = db.DeliveryEmployees.Find(id);
            if (deliveryEmployee == null)
            {
                return HttpNotFound();
            }
            return View(deliveryEmployee);
        }

        // POST: Admin/DeliveryEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Status")] DeliveryEmployee deliveryEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryEmployee);
        }

        // GET: Admin/DeliveryEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEmployee deliveryEmployee = db.DeliveryEmployees.Find(id);
            if (deliveryEmployee == null)
            {
                return HttpNotFound();
            }
            return View(deliveryEmployee);
        }

        // POST: Admin/DeliveryEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryEmployee deliveryEmployee = db.DeliveryEmployees.Find(id);
            db.DeliveryEmployees.Remove(deliveryEmployee);
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