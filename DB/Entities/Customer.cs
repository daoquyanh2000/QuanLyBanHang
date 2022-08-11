using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.DB.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        public string Phone { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}