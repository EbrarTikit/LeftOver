using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CleanArchitecture.Core.Entities
{

    public class Cart:AuditableBaseEntity
    {
        
        public double price { get; set; }
        public int customerId { get; set; }
        public Customer customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}