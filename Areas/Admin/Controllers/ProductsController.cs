using MoreLinq;
using PagedList;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 9;
            var products = db.Products.Include(p => p.ProductType).Include(p => p.Supplier);
            return View(products.ToList().OrderByDescending(p => p.Id).ToPagedList(pageNumber, pageSizeNumber));
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
        public ActionResult Create(Product product, int? selectedImage)
        {
            string pathFolder = "/Assets/Admin/image/";
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
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        Image image = new Image()
                        {
                            ImageName = file.FileName,
                            ImageUrl = pathFolder + fileName,
                        };
                        if (selectedImage == i)
                        {
                            image.IsPrimary = true;
                        }
                        images.Add(image);
                    }
                }
                product.Images = images;
                //set the first image is primary
                if (selectedImage == null && images.Count > 0)
                {
                    product.Images.FirstOrDefault().IsPrimary = true;
                }
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
            Image selectedIamge = db.Images.Where(i => i.IsPrimary == true && i.ProductId == id).FirstOrDefault();
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
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "ID", "Name", product.ProductTypeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "Id", "Name", product.SupplierId);
            string pathFolder = "/Assets/Admin/image/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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

        //delete product image
        [HttpPost]
        public ActionResult ChangePrimaryImage(int productId, int imageId)
        {
            var product = db.Products.Find(productId);
            var images = product.Images;
            images.ToList().ForEach(x => x.IsPrimary = false);
            foreach (var img in images)
            {
                if (img.Id == imageId)
                {
                    img.IsPrimary = true;
                    break;
                }
            }
            product.Images = images;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { Result = "OK" });
        }

        [HttpPost]
        public ActionResult UploadFile(int productId)
        {
            var product = db.Products.Find(productId);
            string pathFolder = "/Assets/Admin/image/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            if (ModelState.IsValid)
            {
                List<Image> images = new List<Image>();
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        Image image = new Image()
                        {
                            ImageName = file.FileName,
                            ImageUrl = pathFolder + fileName,
                        };
                        images.Add(image);
                    }
                }
                product.Images = images;
                //set the first image is primary
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(new { data = "OK" });
        }

        public JsonResult DeleteFile(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
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