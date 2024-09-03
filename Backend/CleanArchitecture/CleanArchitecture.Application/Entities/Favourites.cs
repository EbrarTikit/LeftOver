using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CleanArchitecture.Core.Entities
{

    public class Favourites: AuditableBaseEntity
    {
       
       public int RestaurantId { get; set; }

       public int CustomerId { get; set; }
       public Restaurant Restaurant { get; set; }


        // Other properties
    }
}