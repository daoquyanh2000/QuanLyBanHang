using QuanLyBanHang.DB.Entities;
using System.Collections.Generic;

namespace QuanLyBanHang.Areas.Admin.Models
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryStatus Status { get; set; }
        public string Info { get; set; }
        public string PathImage { get; set; }
        public List<int> ProductIds { get; set; }
    }
}