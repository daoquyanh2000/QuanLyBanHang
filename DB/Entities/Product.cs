using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.DB.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public virtual Supplier Supplier{ get; set; }
        public DateTime CreationTime { get; set; }
    }
}