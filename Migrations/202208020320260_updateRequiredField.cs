namespace QuanLyBanHang.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Category", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Origin", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.ProductType", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProductType", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.Supplier", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Supplier", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.DeliveryEmployee", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Order", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Order", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Order", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
        }

        public override void Down()
        {
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "FullName", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "UserName", c => c.String());
            AlterColumn("dbo.Order", "Phone", c => c.String());
            AlterColumn("dbo.Order", "Address", c => c.String());
            AlterColumn("dbo.Order", "Email", c => c.String());
            AlterColumn("dbo.Order", "FullName", c => c.String());
            AlterColumn("dbo.DeliveryEmployee", "FullName", c => c.String());
            AlterColumn("dbo.Supplier", "Address", c => c.String());
            AlterColumn("dbo.Supplier", "Name", c => c.String());
            AlterColumn("dbo.ProductType", "Info", c => c.String());
            AlterColumn("dbo.ProductType", "Name", c => c.String());
            AlterColumn("dbo.Product", "Info", c => c.String());
            AlterColumn("dbo.Product", "Origin", c => c.String());
            AlterColumn("dbo.Product", "Code", c => c.String());
            AlterColumn("dbo.Product", "Title", c => c.String());
            AlterColumn("dbo.Category", "Info", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
        }
    }
}