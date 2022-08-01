using QuanLyBanHang.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CreateProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductTypeStatus Status { get; set; }
        public string Info { get; set; }
        public string PathImage { get; set; }
    }
}