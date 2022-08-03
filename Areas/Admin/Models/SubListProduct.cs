using QuanLyBanHang.DB.Entities;
using System.Collections.Generic;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class SubListProduct
    {
        public List<IEnumerable<Product>> Products { get; set; }
        public string CategoryName { get; set; }
    }
}