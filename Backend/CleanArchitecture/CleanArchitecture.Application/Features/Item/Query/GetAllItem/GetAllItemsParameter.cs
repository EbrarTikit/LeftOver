using CleanArchitecture.Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Item.Query.GetAllItem
{
    public class GetAllItemsParameter : RequestParameter
    {

        public int restaurantId { get; set; }

        /*public int pageNumber { get; set; }
        public int pageSize { get; set; } */
    }
}