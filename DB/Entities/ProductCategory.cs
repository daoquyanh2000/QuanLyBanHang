using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuanLyBanHang.DB.Entities
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}