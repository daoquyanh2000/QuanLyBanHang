using QuanLyBanHang.DB.Entities;
using System;

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