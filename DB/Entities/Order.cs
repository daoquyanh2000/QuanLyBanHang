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
        public OrderStatus Status { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DeliveryEmployee DeliveryEmployee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public long Total { get; set; }

    }
    public enum OrderStatus
    {
        [Display(Name = "Chờ xác nhận")]
        Pending=0,
        [Display(Name = "Đang giao hàng")]
        Shipping = 1,
        [Display(Name = "Đã giao hàng")]
        Shipped = 2,
        [Display(Name = "Đã hủy")]
        Cancel = 10,
    }
}