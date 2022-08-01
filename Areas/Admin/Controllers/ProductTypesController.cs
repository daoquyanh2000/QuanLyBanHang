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
using QuanLyBanHang.Areas.Admin.Models;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class ProductTypesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin/ProductTypes
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 4;
            var paged = db.ProductTypes.OrderByDescending(x => x.ID).ToList().ToPagedList(pageNumber, pageSizeNumber);
            return View(paged);
        }

        // GET: Admin/ProductTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // GET: Admin/ProductTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProductTypeDto productTypeDto)
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
                var productType = new ProductType()
                {
                    ID = 0,
                    Name = productTypeDto.Name,
                    PathImage = pathImage,
                    Status = productTypeDto.Status,
                    Info = productTypeDto.Info,
                };
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTypeDto);
        }

        // GET: Admin/ProductTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: Admin/ProductTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateProductTypeDto productTypeDto)
        {
            string pathFolder = "/Assets/Admin/image/";
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(Server.MapPath(pathFolder));
            }
            var productType = db.ProductTypes.Find(productTypeDto.Id);
            if (ModelState.IsValid)
            {
                db.ProductTypes.Attach(productType);
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
                        pathImage = productTypeDto.PathImage;
                    }
                }
                //edit data
                productType.Name = productTypeDto.Name;
                productType.Status = productTypeDto.Status;
                productType.Info = productTypeDto.Info;
                productType.PathImage = pathImage;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: Admin/ProductTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: Admin/ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductType productType = db.ProductTypes.Find(id);
            db.ProductTypes.Remove(productType);
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
