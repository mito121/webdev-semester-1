using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class DriverInfo
    {
        public int DriverInfoId { get; set; }
        public string RouteType { get; set; }
        public int DriverLicenseNo { get; set; }
        public DateTime DriverLicenseExperationDate { get; set; }
        public string DriverLicenseImage { get; set; }
        public DateTime TruckLicenseExperationDate { get; set; }
        public string TruckLicenseImage { get; set; }
        public DateTime EuqualificationExperationDate { get; set; }
        public string EuqualificationImage { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }

        public virtual LicenseType Type { get; set; }
        public virtual User User { get; set; }
    }
}
