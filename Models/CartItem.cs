using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanHang.DB.Entities;
namespace QuanLyBanHang.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}