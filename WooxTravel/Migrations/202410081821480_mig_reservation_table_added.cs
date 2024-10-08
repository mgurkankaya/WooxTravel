namespace WooxTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_reservation_table_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Name", c => c.String());
            AddColumn("dbo.Reservations", "Email", c => c.String());
            AddColumn("dbo.Reservations", "Phone", c => c.String());
            AddColumn("dbo.Reservations", "PersonCount", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Description");
            DropColumn("dbo.Reservations", "ReservationDate");
            DropColumn("dbo.Reservations", "PersonCount");
            DropColumn("dbo.Reservations", "Phone");
            DropColumn("dbo.Reservations", "Email");
            DropColumn("dbo.Reservations", "Name");
        }
    }
}
