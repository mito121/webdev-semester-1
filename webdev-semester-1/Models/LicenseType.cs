using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class LicenseType
    {
        public LicenseType()
        {
            DriverInfos = new HashSet<DriverInfo>();
            DriverLicenses = new HashSet<DriverLicense>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<DriverInfo> DriverInfos { get; set; }
        public virtual ICollection<DriverLicense> DriverLicenses { get; set; }
    }
}
