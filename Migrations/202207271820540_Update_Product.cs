namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "ProductType_ID", "dbo.ProductType");
            DropForeignKey("dbo.Product", "Supplier_Id", "dbo.Supplier");
            DropIndex("dbo.Product", new[] { "ProductType_ID" });
            DropIndex("dbo.Product", new[] { "Supplier_Id" });
            RenameColumn(table: "dbo.Product", name: "ProductType_ID", newName: "ProductTypeId");
            RenameColumn(table: "dbo.Product", name: "Supplier_Id", newName: "SupplierId");
            AlterColumn("dbo.Product", "ProductTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "ProductTypeId");
            CreateIndex("dbo.Product", "SupplierId");
            AddForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Product", "SupplierId", "dbo.Supplier", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropIndex("dbo.Product", new[] { "SupplierId" });
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            AlterColumn("dbo.Product", "SupplierId", c => c.Int());
            AlterColumn("dbo.Product", "ProductTypeId", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "SupplierId", newName: "Supplier_Id");
            RenameColumn(table: "dbo.Product", name: "ProductTypeId", newName: "ProductType_ID");
            CreateIndex("dbo.Product", "Supplier_Id");
            CreateIndex("dbo.Product", "ProductType_ID");
            AddForeignKey("dbo.Product", "Supplier_Id", "dbo.Supplier", "Id");
            AddForeignKey("dbo.Product", "ProductType_ID", "dbo.ProductType", "ID");
        }
    }
}
