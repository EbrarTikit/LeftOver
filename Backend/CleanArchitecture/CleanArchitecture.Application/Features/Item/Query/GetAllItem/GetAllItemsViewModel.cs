using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Item.Query.GetAllItem
{
    public class GetAllItemsViewModel

    {
        public int Id { get; set; }
        public int RestaurantID { get; } // Foreign key to Business
        public string itemName { get; set; }
        public double price { get; set; }
        public string picture { get; set; }
        public string explanation { get; set; }
    }
}