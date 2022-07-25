using QuanLyBanHang.Dao;
using QuanLyBanHang.Dao.DaoAdmin;
using QuanLyBanHang.Models;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["TenTaiKhoanNV"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Index(FormCollection fc)
        {
            //kiem tra nguoi dung bam submit chua
            NhanVien UserLogin = new NhanVien();
            UserLogin.TenTaiKhoan = fc["TenTaiKhoan"].ToString();
            UserLogin.MatKhau = fc["MatKhau"].ToString();
            NhanVien User = LoginDao.GetUserByUserNamePassword(UserLogin);
            if (User!=null)
            {
                if (User.TrangThai == 1)
                {
                    Session["HoTenNV"] = User.HoTen;
                    Session["TenTaiKhoanNV"] = User.TenTaiKhoan;
                    Session["IDNV"] = User.ID;
                    return Json(new
                    {
                        status = true,
                        icon = "success",
                        heading = "Thành công",
                        message = "Đăng nhập thành công!"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        heading = "Có lỗi",
                        icon = "warning",
                        message = "Tài khoản đăng nhập đã bị khóa!"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    heading = "Có lỗi",
                    icon = "error",
                    message = "Tài khoản không tồn tại hoặc sai thông tin đăng nhập!"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}