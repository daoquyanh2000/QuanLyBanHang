using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBanHang.DB.Entities
{
    public class Image
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}