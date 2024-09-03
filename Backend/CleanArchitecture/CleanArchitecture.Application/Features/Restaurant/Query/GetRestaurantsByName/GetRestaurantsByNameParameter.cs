using CleanArchitecture.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName
{
    public class GetRestaurantsByNameParameter : RequestParameter
    {
        public string SearchString { get; set; }
    }
}
