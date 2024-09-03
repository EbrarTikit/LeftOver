using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CleanArchitecture.Core.Entities
{

    public class Restaurant: AuditableBaseEntity
    {
        public string Name { get; set; } // Foreign key to Business
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetInformation { get; set; }
        public string City { get; set; }    
        public string postalCode { get; set; }
        public string Country { get; set; }
        public string StoreType { get; set; }
        public string Picture { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<Reservation> Reservations { get; set; }


        // public LinkedList<Item> Items { get; set; }
        // Other properties
    }
}