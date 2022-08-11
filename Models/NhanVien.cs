using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Dapper.Contrib.Extensions.Key]
        public long ID { get; set; }

        [Display(Name = "Tên người dùng")]
        public string HoTen { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string TenTaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        public string Email { get; set; }
    }
}