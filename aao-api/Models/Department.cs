using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? Phone { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
