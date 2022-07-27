namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init_remain_table : DbMigration
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
                        ProductType_ID = c.Int(),
                        Supplier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductType", t => t.ProductType_ID)
                .ForeignKey("dbo.Supplier", t => t.Supplier_Id)
                .Index(t => t.ProductType_ID)
                .Index(t => t.Supplier_Id);
            
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
                .Index(t => t.OrderId);
            
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
                "dbo.Specification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Size = c.String(),
                        Weight = c.Single(nullable: false),
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
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "DeliveryEmployee_Id", "dbo.DeliveryEmployee");
            DropForeignKey("dbo.Product", "Supplier_Id", "dbo.Supplier");
            DropForeignKey("dbo.Product", "ProductType_ID", "dbo.ProductType");
            DropForeignKey("dbo.Image", "ProductId", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.ProductCategory", "Product_Id", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "Category_Id" });
            DropIndex("dbo.ProductCategory", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "DeliveryEmployee_Id" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Image", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "Supplier_Id" });
            DropIndex("dbo.Product", new[] { "ProductType_ID" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Specification");
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
