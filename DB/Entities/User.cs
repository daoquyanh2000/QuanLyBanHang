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
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Họ tên")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Trạng thái")]
        [Required]
        public UserStatus Status { get; set; }
        [Display(Name = "Ngày tạo")]

        public DateTime? CreatedDate { get; set; }
    }
    public enum UserStatus
    {
            [Display(Name = "Khóa")]
            FirstValue=0,
            [Display(Name = "Mở")]
            SecondValue=1,
    }
}