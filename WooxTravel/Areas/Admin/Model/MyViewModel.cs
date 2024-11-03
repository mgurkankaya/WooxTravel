using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Model
{
    public class MyViewModel
    {
      
        public IEnumerable<Destination> Destinations { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}