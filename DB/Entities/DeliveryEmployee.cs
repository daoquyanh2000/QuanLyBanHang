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
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Trạng thái")]
        [Required]
        public DeliveryEmployeeStatus Status { get; set; }
        public string Phone { get; set; }
    }
    public enum DeliveryEmployeeStatus
    {
        [Display(Name = "Đang giao hàng")]
        Inactive = 0,
        [Display(Name = "Rảnh")]
        Active = 1,
    }
}