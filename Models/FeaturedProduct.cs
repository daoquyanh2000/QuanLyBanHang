using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class FeaturedProduct
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<Product> Products { get; set; }
    }
}