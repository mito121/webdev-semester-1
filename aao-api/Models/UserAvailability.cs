using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class UserAvailability
    {
        public int UserId { get; set; }
        public int AvailabilityId { get; set; }

        public virtual Availability Availability { get; set; }
        public virtual User User { get; set; }
    }
}
