using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.DB.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Trạng thái")]
        public Status Status { get; set; }
        [Display(Name = "Ngày tạo")]

        public DateTime? CreatedDate { get; set; }
    }
    public enum Status
    {
            [Display(Name = "Khóa")]
            FirstValue=0,
            [Display(Name = "Mở")]
            SecondValue=1
    }
}