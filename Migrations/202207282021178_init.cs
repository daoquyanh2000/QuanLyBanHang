namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Code = c.String(),
                        Price = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Origin = c.String(),
                        Info = c.String(),
                        Stock = c.Int(nullable: false),
                        Specification = c.String(),
                        ProductType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductType", t => t.ProductType_ID)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.ProductType_ID);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryEmployee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        PricePerUnit = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Money = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedTime = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                        CustomerEmail = c.String(),
                        DeliveryAddress = c.String(),
                        Status = c.Int(nullable: false),
                        Total = c.Long(nullable: false),
                        DeliveryEmployee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryEmployee", t => t.DeliveryEmployee_Id)
                .Index(t => t.DeliveryEmployee_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.ProductId })
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "DeliveryEmployee_Id", "dbo.DeliveryEmployee");
            DropForeignKey("dbo.ProductCategory", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Product", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Product", "ProductType_ID", "dbo.ProductType");
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "ProductId" });
            DropIndex("dbo.ProductCategory", new[] { "CategoryId" });
            DropIndex("dbo.Order", new[] { "DeliveryEmployee_Id" });
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Image", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "ProductType_ID" });
            DropIndex("dbo.Product", new[] { "SupplierId" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.DeliveryEmployee");
            DropTable("dbo.Supplier");
            DropTable("dbo.ProductType");
            DropTable("dbo.Image");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
