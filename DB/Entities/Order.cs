using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.DB.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public virtual DeliveryEmployee DeliveryEmployee { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [Required]
        public long Total { get; set; }
    }

    public enum OrderStatus
    {
        [Display(Name = "Chờ xác nhận")]
        Pending = 0,

        [Display(Name = "Đang giao hàng")]
        Shipping = 1,

        [Display(Name = "Đã giao hàng")]
        Shipped = 2,

        [Display(Name = "Đã hủy")]
        Cancel = 10,
    }
}