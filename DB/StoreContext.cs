using QuanLyBanHang.DB.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace QuanLyBanHang.DB
{
    public class StoreContext : System.Data.Entity.DbContext
    {
        public StoreContext() : base("StoreContext")
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}