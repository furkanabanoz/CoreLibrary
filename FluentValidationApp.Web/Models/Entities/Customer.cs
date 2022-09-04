using System;
using System.Collections.Generic;

namespace FluentValidationApp.Web.Models.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public DateTime? BirthDay { get; set; } //soru işareti null olabileceği anlamına geliyor.

        public IList<Address> Addresses  { get; set; }//burada birden fazla adress olabileceğinden dolayı burada
                                                      //IList üzerinden entitiymizi giriyoruz

        public Gender gender { get; set; }
    }
}
