using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanHang.DB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public long Price { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public string Origin { get; set; }
        public string Info { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Image> Images { get; set; }
        public int Stock { get; set; }
    }
}