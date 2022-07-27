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
        public string FullName { get; set; }
        public int Status { get; set; }
    }
}