using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class Availability
    {
        public Availability()
        {
            UserAvailabilities = new HashSet<UserAvailability>();
        }

        public int AvailabilityId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public virtual ICollection<UserAvailability> UserAvailabilities { get; set; }
    }
}
