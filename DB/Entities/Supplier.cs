using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.DB.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        [Display(Name = "Nhà cung cấp")]

        public string Name { get; set; }
        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }
    }
}