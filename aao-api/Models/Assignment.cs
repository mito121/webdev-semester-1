using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class Assignment
    {
        public int AssignmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public bool? Urgent { get; set; }
        public bool? AllDay { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string CountryCodeStart { get; set; }
        public string CountryCodeEnd { get; set; }
        public bool Available { get; set; }
        public int StatusId { get; set; }
        public int StartCityId { get; set; }
        public int ContactUserId { get; set; }
        public int? ReplacementUserId { get; set; }
        public int DriverUserId { get; set; }

        public virtual User ContactUser { get; set; }
        public virtual User DriverUser { get; set; }
        public virtual User ReplacementUser { get; set; }
        public virtual City StartCity { get; set; }
        public virtual Status Status { get; set; }
    }
}
