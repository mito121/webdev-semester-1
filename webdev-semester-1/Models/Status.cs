using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class Status
    {
        public Status()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
