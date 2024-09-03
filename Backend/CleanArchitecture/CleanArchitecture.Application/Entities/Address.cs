using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CleanArchitecture.Core.Entities
{
    public class Address : AuditableBaseEntity
    {
       
        public string UserName { get; set; }
        public string AddressDefinition { get; set; } //avene street and other info
        public string City { get; set; }
        public string Town { get; set; }
        public string Neighbourhood { get; set; }
        public int BuildingNo {  get; set; }
        public int Floor {  get; set; }
        public string AddressTitle { get; set; }
        public string AdressDirection { get; set; }

        public Customer Customer { get; set; }

        //Database Modified
    }
}
