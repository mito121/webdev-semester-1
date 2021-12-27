using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class User
    {
        public User()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            AssignmentContactUsers = new HashSet<Assignment>();
            AssignmentDriverUsers = new HashSet<Assignment>();
            AssignmentReplacementUsers = new HashSet<Assignment>();
            DriverInfos = new HashSet<DriverInfo>();
            DriverLicenses = new HashSet<DriverLicense>();
            MessageReceiverUsers = new HashSet<Message>();
            MessageSenderUsers = new HashSet<Message>();
            UserAvailabilities = new HashSet<UserAvailability>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int? AddressId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual Address Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
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
