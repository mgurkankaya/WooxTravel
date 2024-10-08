namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_email_column_removed_on_reservation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Email", c => c.String());
        }
    }
}
