using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CleanArchitecture.Core.Entities
{
    public class Customer : AuditableBaseEntity
    {
        public string CId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        ICollection<Reservation> reservations { get; set; }
        public Cart Cart { get; set; } 





        //Database Modified

    }
}