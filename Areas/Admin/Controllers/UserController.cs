using Dapper.Contrib.Extensions;
using PagedList;
using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string keyword, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSizeNumber = 4;
            if (keyword == null) keyword = "";
            var results = from nv in Stuff.GetAll<NhanVien>()
                          where (nv.HoTen.Contains(keyword) ||
                          nv.TenTaiKhoan.Contains(keyword))
                          && nv.TrangThai != 10
                          orderby nv.ID descending
                          select nv;
            ViewBag.search = keyword;
            var model = results.ToPagedList(pageNumber, pageSizeNumber);
            return View(model);
        }

        public ActionResult Create()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Value="0",Text="Khóa"},
                 new SelectListItem{ Value="1",Text="Mở"},
             };
            myList = data.ToList();
            Session["listTrangThai"] = myList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhanVien nv)
        {
            using (IDbConnection db = new SqlConnection(ConnectString.Setup()))
            {
                db.Insert(nv);
            }
            ViewBag.Message = "Lưu thành công";
            return View();
        }

        public ActionResult Edit(long id)
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Value="0",Text="Khóa"},
                 new SelectListItem{ Value="1",Text="Mở"},
             };
            myList = data.ToList();
            Session["listTrangThai"] = myList;
            var user = Stuff.GetByID<NhanVien>(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            using (IDbConnection db = new SqlConnection(ConnectString.Setup()))
            {
                db.Insert(nv);
            }
            ViewBag.Message = "Lưu thành công";
            return View();
        }

        public ActionResult Delete(long id)
        {
            var user = Stuff.GetByID<NhanVien>(id);
            user.TrangThai = 10;
            using (IDbConnection db = new SqlConnection(ConnectString.Setup()))
            {
                db.Update(user);
            }
            return RedirectToAction("Index");
        }
    }
}