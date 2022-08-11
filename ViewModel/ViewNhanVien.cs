using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.ViewModel
{
    public class ViewNhanVien
    {
        public string HoTen { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string TenTaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        public int TrangThai { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
}