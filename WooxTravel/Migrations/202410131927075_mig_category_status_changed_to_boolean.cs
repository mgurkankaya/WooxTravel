namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_category_status_changed_to_boolean : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryStatus", c => c.String());
        }
    }
}
