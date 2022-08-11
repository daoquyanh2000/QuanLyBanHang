using Dapper.Contrib.Extensions;
using QuanLyBanHang.Dao;
using QuanLyBanHang.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["TenTaiKhoanNV"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public ActionResult Edit(long id)
        {
            var user = Stuff.GetByID<NhanVien>(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            using (IDbConnection db = new SqlConnection(ConnectString.Setup()))
            {
                nv.TrangThai = 1;
                db.Update(nv);
            }
            Session["HoTenNV"] = nv.HoTen;
            Session["TenTaiKhoanNV"] = nv.TenTaiKhoan;
            ViewBag.Message = "Lưu thành công";
            return View();
        }
    }
}