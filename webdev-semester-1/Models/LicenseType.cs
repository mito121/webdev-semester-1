using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class LicenseType
    {
        public LicenseType()
        {
            ChauffeurInfos = new HashSet<ChauffeurInfo>();
            ChauffeurLicenses = new HashSet<ChauffeurLicense>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<ChauffeurInfo> ChauffeurInfos { get; set; }
        public virtual ICollection<ChauffeurLicense> ChauffeurLicenses { get; set; }
    }
}
