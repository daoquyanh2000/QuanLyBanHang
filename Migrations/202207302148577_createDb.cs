namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
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
                        Origin = c.String(),
                        Info = c.String(),
                        Stock = c.Int(nullable: false),
                        Specification = c.String(),
                        ProductTypeId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProductTypeId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageName = c.String(),
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
            
            CreateTable(
                "dbo.DeliveryEmployee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Status = c.Int(nullable: false),
                        Phone = c.String(),
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
                        Status = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Total = c.Long(nullable: false),
                        DeliveryEmployee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.DeliveryEmployee", t => t.DeliveryEmployee_Id)
                .Index(t => t.CustomerId)
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
                        Product_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Category_Id })
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "DeliveryEmployee_Id", "dbo.DeliveryEmployee");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Product", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ProductCategory", "Product_Id", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategory", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "DeliveryEmployee_Id" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Image", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "SupplierId" });
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.DeliveryEmployee");
            DropTable("dbo.Customer");
            DropTable("dbo.Supplier");
            DropTable("dbo.ProductType");
            DropTable("dbo.Image");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
