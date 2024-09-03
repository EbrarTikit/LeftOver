using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace CleanArchitecture.Core.Entities
{

    public class Reservation: AuditableBaseEntity
    {
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }  

        public ICollection<ReservationItem> ReservationItems { get; set; }

        public bool isDelivered { get; set; }
        public bool isCancelled { get; set; }
        public double totalPrice { get; set; }
        public string ReservationCode { get; set; }



        // Other properties
    }
}