using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Cart.Query.GetCardByCustomerId
{
    public class GetCardByIdViewModel 
    {

        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public int Quantity { get; set; }

    }
}
