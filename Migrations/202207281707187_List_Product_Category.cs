namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class List_Product_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Stock");
        }
    }
}
