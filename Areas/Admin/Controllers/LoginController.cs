using QuanLyBanHang.Dao;
using QuanLyBanHang.Dao.DaoAdmin;
using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.Models;
using System.Web.Mvc;

namespace QuanLyBanHang.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        static StoreContext context = new StoreContext();
        private LoginDao loginDao = new LoginDao(context);
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
            NhanVien UserLogin = new NhanVien();
            UserLogin.TenTaiKhoan = fc["TenTaiKhoan"].ToString();
            UserLogin.MatKhau = fc["MatKhau"].ToString();
            User user = loginDao.GetUserByUserNamePassword(UserLogin);
            if (user!=null)
            {
                if (user.Status ==Status.SecondValue)
                {
                    Session["HoTenNV"] = user.FullName;
                    Session["TenTaiKhoanNV"] = user.UserName;
                    Session["IDNV"] = user.Id;
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