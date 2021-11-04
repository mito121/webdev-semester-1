using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class ChauffeurLicense
    {
        public int ChauffeurId { get; set; }
        public int TypeId { get; set; }

        public virtual User Chauffeur { get; set; }
        public virtual LicenseType Type { get; set; }
    }
}
