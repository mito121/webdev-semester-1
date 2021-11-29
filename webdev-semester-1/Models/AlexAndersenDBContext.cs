using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class AlexAndersenDBContext : IdentityDbContext<User, Role, int>
    {
        public AlexAndersenDBContext()
        {
        }

        public AlexAndersenDBContext(DbContextOptions<AlexAndersenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DriverInfo> DriverInfos { get; set; }
        public virtual DbSet<DriverLicense> DriverLicenses { get; set; }
        public virtual DbSet<LicenseType> LicenseTypes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAvailability> UserAvailabilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
