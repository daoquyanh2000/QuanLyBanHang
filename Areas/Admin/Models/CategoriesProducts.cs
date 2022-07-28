using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CategoriesProducts
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}