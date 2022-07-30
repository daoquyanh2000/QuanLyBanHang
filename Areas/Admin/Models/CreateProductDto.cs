using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CreateProductDto : Product
    {
        public List<int> isPrimary { get; set; }
    }
}