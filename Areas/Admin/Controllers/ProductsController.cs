using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 2;
            var products = db.Products.Include(p => p.ProductType).Include(p => p.Supplier);
            return View(products.ToList().OrderByDescending(p=>p.Id).ToPagedList(pageNumber, pageSizeNumber));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ID", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product product)
        {
            string pathFolder = "/App_Data/Upload/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            if (ModelState.IsValid)
            {
                List<Image> images = new List<Image>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.Ticks.ToString() + "_"+ Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        Image image = new Image()
                        {
                            ImageName = fileName,
                            ImageUrl = pathFolder + fileName,
                        };
                        images.Add(image);
                    }
                }
                product.Images = images;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ID", "Name", product.ProductTypeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ID", "Name", product.ProductTypeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            string pathFolder = "/App_Data/Upload/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            if (ModelState.IsValid)
            {
                List<Image> images = new List<Image>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(pathFolder, fileName);
                        file.SaveAs(path);

                        Image image = new Image()
                        {
                            ImageName = fileName,
                            ImageUrl = pathFolder+ fileName,
                        };
                        images.Add(image);
                    }
                }
                product.Images = images;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ID", "Name", product.ProductTypeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        //delete product image
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Image image = db.Images.Find(id);
                if (image == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.Images.Remove(image);
                db.SaveChanges();

                //Delete file from the file system
                var path = Server.MapPath(image.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
