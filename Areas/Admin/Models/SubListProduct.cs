using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanHang.DB.Entities;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class SubListProduct
    {
        public List<IEnumerable<Product>> Products { get; set; }
        public string CategoryName { get; set; }

    }
}