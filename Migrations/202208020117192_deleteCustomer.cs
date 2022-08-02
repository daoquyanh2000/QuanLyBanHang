namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerId" });
            AddColumn("dbo.Order", "FullName", c => c.String());
            AddColumn("dbo.Order", "Email", c => c.String());
            AddColumn("dbo.Order", "Address", c => c.String());
            AddColumn("dbo.Order", "Phone", c => c.String());
            DropColumn("dbo.Order", "CustomerId");
            DropTable("dbo.Customer");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Order", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Phone");
            DropColumn("dbo.Order", "Address");
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "FullName");
            CreateIndex("dbo.Order", "CustomerId");
            AddForeignKey("dbo.Order", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
