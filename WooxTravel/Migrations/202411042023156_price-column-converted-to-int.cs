namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricecolumnconvertedtoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Destinations", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Destinations", "Price", c => c.String());
        }
    }
}
