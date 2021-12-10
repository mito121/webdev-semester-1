using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webdev_semester_1.ViewModels
{
    public class UserProfileVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }

        public string AddressName { get; set; }
        public int PostalCode { get; set; }
        public int CityId { get; set; }
    }
}
