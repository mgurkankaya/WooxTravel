using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WooxTravel.Entities;

namespace WooxTravel.Context
{
    public class TravelContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}