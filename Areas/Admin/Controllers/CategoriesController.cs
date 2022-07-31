using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.Areas.Admin.Models;
using PagedList;
using System.IO;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/Categories
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 4;
            var paged = db.Categories.OrderByDescending(x=>x.Id).ToList().ToPagedList(pageNumber, pageSizeNumber);
            return View(paged);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            var products = db.Products.ToList();
            ViewBag.products = products;
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryDto categoryDto)
        {
            string pathFolder = "/Assets/Admin/image/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            if (ModelState.IsValid)
            {
                string pathImage = string.Empty;
                //save image
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        pathImage = pathFolder + fileName;
                    }
                }

                var products = db.Products.Where(x => categoryDto.ProductIds.Contains(x.Id)).ToList();
                if (!products.Any())
                {
                    return RedirectToAction("Index");

                }
                var category = new Category() { 
                    Id = 0, 
                    Name = categoryDto.Name,
                    PathImage = pathImage,
                    Status=categoryDto.Status,
                    Info=categoryDto.Info,
                    Products = products };

                db.Entry(category).State = EntityState.Added;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryDto);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            var products = db.Products.ToList();
            ViewBag.products = products;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateCategoryDto categoryDto)
        {
            string pathFolder = "/Assets/Admin/image/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            var category = db.Categories.Include("Products").Single(c => c.Id == categoryDto.Id);
            if (ModelState.IsValid)
            {
                string pathImage = string.Empty;
                //save image
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(file.FileName);
                        //save file
                        var path = Path.Combine(Server.MapPath(pathFolder), fileName);
                        file.SaveAs(path);
                        pathImage = pathFolder + fileName;
                    }
                    else
                    {
                        pathImage = categoryDto.PathImage;
                    }
                }
                //edit data
                category.Name = categoryDto.Name;
                category.Status = categoryDto.Status;
                category.Info = categoryDto.Info;
                category.PathImage = pathImage;
                foreach (var product in category.Products.ToList())
                {
                    //remove the product if not in list of product
                    if (!categoryDto.ProductIds.Contains(product.Id))
                    {
                        category.Products.Remove(product);
                    }
                }
                foreach (var productId in categoryDto.ProductIds)
                {
                    //Add the product which are not in the list of category's product
                    if (!category.Products.Select(x => x.Id).Contains(productId))
                    {
                        var newProduct = new Product
                        {
                            Id = productId,
                        };
                        db.Products.Attach(newProduct);
                        category.Products.Add(newProduct);
                    }
                }

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
