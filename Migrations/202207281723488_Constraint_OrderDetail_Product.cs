namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Constraint_OrderDetail_Product : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderDetail", "ProductId");
            AddForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
        }
    }
}
