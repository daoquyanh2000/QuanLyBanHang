using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.DB.Entities
{
    public class ProductType
    {
        public int ID { get; set; }

        [Display(Name = "Tên loại")]
        [Required]
        public string Name { get; set; }

        public string PathImage { get; set; }

        [Display(Name = "Thông tin")]
        [Required]
        public string Info { get; set; }

        [Display(Name = "Trạng thái")]
        [Required]
        public ProductTypeStatus Status { get; set; }
    }

    public enum ProductTypeStatus
    {
        [Display(Name = "Vô hiệu hóa")]
        Inactive = 0,

        [Display(Name = "Đang hoạt động")]
        Active = 1,
    }
}