using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class ReservationItem:AuditableBaseEntity
    {
        public int Quantity { get; set; }

        public int ReservationID { get; set;}
        public Reservation Reservation { get; set; }

        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
