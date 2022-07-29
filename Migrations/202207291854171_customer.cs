namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "Specification", c => c.String());
            AddColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "CustomerId");
            AddForeignKey("dbo.Order", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            DropColumn("dbo.Order", "CustomerName");
            DropColumn("dbo.Order", "CustomerEmail");
            DropColumn("dbo.Order", "DeliveryAddress");
            DropTable("dbo.Specification");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Specification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Size = c.String(),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "DeliveryAddress", c => c.String());
            AddColumn("dbo.Order", "CustomerEmail", c => c.String());
            AddColumn("dbo.Order", "CustomerName", c => c.String());
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropColumn("dbo.Order", "CustomerId");
            DropColumn("dbo.Product", "Specification");
            DropTable("dbo.Customer");
        }
    }
}
