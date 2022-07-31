namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "PathImage", c => c.String());
            AddColumn("dbo.Category", "Info", c => c.String());
            AddColumn("dbo.Category", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Status");
            DropColumn("dbo.Category", "Info");
            DropColumn("dbo.Category", "PathImage");
        }
    }
}
