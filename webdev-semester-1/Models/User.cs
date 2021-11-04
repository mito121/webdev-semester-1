using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class User
    {
        public User()
        {
            AssignmentChauffeurs = new HashSet<Assignment>();
            AssignmentContactUsers = new HashSet<Assignment>();
            AssignmentReplacementUsers = new HashSet<Assignment>();
            ChauffeurLicenses = new HashSet<ChauffeurLicense>();
            MessageReceiverUsers = new HashSet<Message>();
            MessageSenderUsers = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int? DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int? AddressId { get; set; }
        public int? ChauffeurInfoId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ChauffeurInfo ChauffeurInfo { get; set; }
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Assignment> AssignmentChauffeurs { get; set; }
        public virtual ICollection<Assignment> AssignmentContactUsers { get; set; }
        public virtual ICollection<Assignment> AssignmentReplacementUsers { get; set; }
        public virtual ICollection<ChauffeurLicense> ChauffeurLicenses { get; set; }
        public virtual ICollection<Message> MessageReceiverUsers { get; set; }
        public virtual ICollection<Message> MessageSenderUsers { get; set; }
    }
}
