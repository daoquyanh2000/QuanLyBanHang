using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyBanHang.DB.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required]
        public string Name { get; set; }
        public string PathImage { get; set; }
        [Display(Name = "Thông tin")]
        [Required]
        public string Info { get; set; }
        [Display(Name = "Trạng thái")]
        [Required]
        public CategoryStatus Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public enum CategoryStatus
    {
        [Display(Name = "Vô hiệu hóa")]
        Inactive = 0,
        [Display(Name = "Đang hoạt động")]
        Active = 1,
    }
}