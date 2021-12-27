using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class AspNetRoleClaim
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual Role Role { get; set; }
    }
}
