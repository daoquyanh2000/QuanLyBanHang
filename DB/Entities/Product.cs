using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanHang.DB.Entities
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        [Display(Name = "Tên")]
        public string Title { get; set; }
        [Display(Name = "Mã")]
        public string Code { get; set; }
        [Display(Name = "Giá")]
        public long Price { get; set; }
        [Display(Name = "Trạng thái")]
        public ProductStatus Status { get; set; }
        [Display(Name = "Giảm giá")]
        public int Discount { get; set; }


        [Display(Name = "Xuất xứ")]
        public string Origin { get; set; }
        [Display(Name = "Thông tin")]
        public string Info { get; set; }
        [Display(Name = "Trong kho")]
        public int Stock { get; set; }
        [Display(Name = "Thông số")]
        public string Specification { get; set; }
        [Display(Name = "Thông tin chi tiết")]
        public string Description { get; set; }
        [Display(Name = "Danh mục")]
        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("ProductType")]
        [Display(Name = "Loại sản phẩm")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Image> Images { get; set; }

    }
    public enum ProductStatus
    {
        [Display(Name = "Vô hiệu hóa")]
        Inactive = 0,
        [Display(Name = "Đang hoạt động")]
        Active = 1,
    }
}