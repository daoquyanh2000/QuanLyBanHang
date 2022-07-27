using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanHang.DB.Entities;
namespace QuanLyBanHang.DB
{
    public class StoreInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var users = new List<User>
            {
                new User{Id=1,Email="abc@gmail.com",FullName="admin",UserName="admin",Password="123",CreatedDate=DateTime.Now }
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}