using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Assignments = new HashSet<Assignment>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
