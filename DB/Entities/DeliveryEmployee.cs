using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QuanLyBanHang.DB.Entities
{
    public class DeliveryEmployee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Họ tên")]
        public string FullName { get; set; }
        [Display(Name = "Trạng thái")]
        public DeliveryEmployeeStatus Status { get; set; }
    }
    public enum DeliveryEmployeeStatus
    {
        [Display(Name = "Đang giao hàng")]
        FirstValue = 0,
        [Display(Name = "Rảnh")]
        SecondValue = 1,
    }
}