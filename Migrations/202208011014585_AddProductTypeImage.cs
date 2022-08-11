namespace QuanLyBanHang.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddProductTypeImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Description", c => c.String());
            AddColumn("dbo.ProductType", "PathImage", c => c.String());
            AddColumn("dbo.ProductType", "Info", c => c.String());
            AddColumn("dbo.ProductType", "Status", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.ProductType", "Status");
            DropColumn("dbo.ProductType", "Info");
            DropColumn("dbo.ProductType", "PathImage");
            DropColumn("dbo.Product", "Description");
        }
    }
}