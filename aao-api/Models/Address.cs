using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public int PostalCode { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
