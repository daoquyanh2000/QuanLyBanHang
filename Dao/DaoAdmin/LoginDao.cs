using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Dao.DaoAdmin
{
    public class LoginDao
    {
        public static NhanVien GetUserByUserNamePassword(NhanVien model)
        {
            string queryString = $"SELECT * FROM [NhanVien] WHERE TenTaiKhoan ='{model.TenTaiKhoan}' and MatKhau ='{model.MatKhau}'";
            var user = Stuff.GetList<NhanVien>(queryString).FirstOrDefault();
            return user;
        }
    }
}