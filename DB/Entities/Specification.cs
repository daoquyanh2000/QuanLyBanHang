using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.DB.Entities
{
    public class Specification
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public float Weight { get; set; }

    }
}