using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
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
