using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyBanHang.DB.Entities;

namespace QuanLyBanHang.DB.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public int Status { get; set; }
        public virtual DeliveryEmployee DeliveryEmployee { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public long Total { get; set; }

    }
}