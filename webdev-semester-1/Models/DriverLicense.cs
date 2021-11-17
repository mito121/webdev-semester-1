using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class DriverLicense
    {
        public int DriverId { get; set; }
        public int TypeId { get; set; }

        public virtual User Driver { get; set; }
        public virtual LicenseType Type { get; set; }
    }
}
