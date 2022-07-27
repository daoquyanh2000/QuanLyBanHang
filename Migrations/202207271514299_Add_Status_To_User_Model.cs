namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Status_To_User_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Status");
        }
    }
}
