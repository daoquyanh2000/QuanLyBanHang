namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using QuanLyBanHang.DB.Entities;
    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyBanHang.DB.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLyBanHang.DB.StoreContext context)
        {
            var users = new List<User>
            {
                new User{Id=1,Email="abc@gmail.com",FullName="admin",UserName="tkadmin",Password="123456",CreatedDate=DateTime.Now,Status =UserStatus.SecondValue }
            };
            base.Seed(context);
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
