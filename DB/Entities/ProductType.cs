using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.DB.Entities
{
    public class ProductType
    {
        public int ID { get; set; }
        [Display(Name = "Tên loại")]
        public string Name { get; set; }
    }
}