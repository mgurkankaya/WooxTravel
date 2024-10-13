namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
