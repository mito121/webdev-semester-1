using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class ChauffeurInfo
    {
        public ChauffeurInfo()
        {
            Users = new HashSet<User>();
        }

        public int ChauffeurInfoId { get; set; }
        public string RouteType { get; set; }
        public int DriverLicenseNo { get; set; }
        public DateTime DriverLicenseExperationDate { get; set; }
        public string DriverLicenseImage { get; set; }
        public bool? TruckLicense { get; set; }
        public DateTime? TruckLicenseExperationDate { get; set; }
        public string TruckLicenseImage { get; set; }
        public bool? EuQualification { get; set; }
        public DateTime? EuQualificationExperationDate { get; set; }
        public int TypeId { get; set; }

        public virtual LicenseType Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
