using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants
{
    public class GetAllRestaurantsViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetInformation { get; set; }
        public string City { get; set; }
        public string postalCode { get; set; }
        public string Country { get; set; }
        public string StoreType { get; set; }
     
    }
}
