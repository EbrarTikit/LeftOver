using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Filters;


namespace CleanArchitecture.Core.Features.Address.Query.GetAllAddresses
{
    public class GetAllAddressesParameter
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
