using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class AspNetUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
