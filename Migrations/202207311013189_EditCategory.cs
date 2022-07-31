namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "PathImage", c => c.String());
            AddColumn("dbo.Category", "Info", c => c.String());
            AddColumn("dbo.Category", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
