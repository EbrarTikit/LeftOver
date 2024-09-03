using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Features.Address.Query.GetAllAddresses
{
    public class GetAllAddressesViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string AddressDefinition { get; set; } //avene street and other info
        public string City { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public int BuildingNo { get; set; }
        public int Floor { get; set; }
        public string AddressTitle { get; set; }
        public string AdressDirection { get; set; }
    }
}
