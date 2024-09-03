using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CleanArchitecture.Core.Entities
{

    public class CartItem: AuditableBaseEntity
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int pieceNumber { get; set; }
       
        

        
    }
} 