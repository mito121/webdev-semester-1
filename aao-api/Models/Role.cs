using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class Role
    {
        public Role()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
