using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyBanHang.DB.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Product")]
        public virtual List<int> ProductIds { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}