using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            AssignmentContactUsers = new HashSet<Assignment>();
            AssignmentDriverUsers = new HashSet<Assignment>();
            AssignmentReplacementUsers = new HashSet<Assignment>();
            DriverInfos = new HashSet<DriverInfo>();
            DriverLicenses = new HashSet<DriverLicense>();
            MessageReceiverUsers = new HashSet<Message>();
            MessageSenderUsers = new HashSet<Message>();
            UserAvailabilities = new HashSet<UserAvailability>();
        }

        //public int UserId { get; set; }
        //public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Mail { get; set; }
        //public int Phone { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Assignment> AssignmentContactUsers { get; set; }
        public virtual ICollection<Assignment> AssignmentDriverUsers { get; set; }
        public virtual ICollection<Assignment> AssignmentReplacementUsers { get; set; }
        public virtual ICollection<DriverInfo> DriverInfos { get; set; }
        public virtual ICollection<DriverLicense> DriverLicenses { get; set; }
        public virtual ICollection<Message> MessageReceiverUsers { get; set; }
        public virtual ICollection<Message> MessageSenderUsers { get; set; }
        public virtual ICollection<UserAvailability> UserAvailabilities { get; set; }
    }
}
