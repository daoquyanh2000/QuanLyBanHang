using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class UpdateCartDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}