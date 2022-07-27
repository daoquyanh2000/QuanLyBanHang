using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Sql;
namespace QuanLyBanHang.DB.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order {get;set;}
        public int ProductId { get; set; }
        public long PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public double Money { get; set; }

   
    }
}