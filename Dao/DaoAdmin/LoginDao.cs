﻿using QuanLyBanHang.DB;
using QuanLyBanHang.DB.Entities;
using QuanLyBanHang.Models;
using System.Linq;

namespace QuanLyBanHang.Dao.DaoAdmin
{
    public class LoginDao
    {
        private StoreContext context;

        public LoginDao(StoreContext context)
        {
            this.context = context;
        }

        public User GetUserByUserNamePassword(NhanVien model)
        {
            User user = this.context.Users.Where(x => x.UserName == model.TenTaiKhoan).FirstOrDefault();
            return user;
        }
    }
}