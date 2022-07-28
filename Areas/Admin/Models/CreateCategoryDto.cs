using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }
    }
}