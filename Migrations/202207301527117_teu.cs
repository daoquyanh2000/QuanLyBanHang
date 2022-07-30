namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SelectedImage", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "SelectedImage");
        }
    }
}
