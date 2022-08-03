using QuanLyBanHang.DB.Entities;
using System.Collections.Generic;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CategoriesProducts
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}