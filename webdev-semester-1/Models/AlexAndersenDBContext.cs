using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webdev_semester_1.Models
{
    //public partial class AlexAndersenDBContext : DbContext
    public partial class AlexAndersenDBContext : IdentityDbContext<User, Role, int>
    {


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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CDG7Q1\\SQLEXPRESS;Database=AlexAndersenDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Address__CityID__30F848ED");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignment");

                entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");

                entity.Property(e => e.ContactUserId).HasColumnName("ContactUserID");

                entity.Property(e => e.CountryCodeEnd)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CountryCodeStart)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DriverUserId).HasColumnName("DriverUserID");

                entity.Property(e => e.ReplacementUserId).HasColumnName("ReplacementUserID");

                entity.Property(e => e.StartCityId).HasColumnName("StartCityID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.ContactUser)
                    .WithMany(p => p.AssignmentContactUsers)
                    .HasForeignKey(d => d.ContactUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Conta__4AB81AF0");

                entity.HasOne(d => d.DriverUser)
                    .WithMany(p => p.AssignmentDriverUsers)
                    .HasForeignKey(d => d.DriverUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Drive__4CA06362");

                entity.HasOne(d => d.ReplacementUser)
                    .WithMany(p => p.AssignmentReplacementUsers)
                    .HasForeignKey(d => d.ReplacementUserId)
                    .HasConstraintName("FK__Assignmen__Repla__4BAC3F29");

                entity.HasOne(d => d.StartCity)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.StartCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Start__49C3F6B7");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Statu__48CFD27E");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.ToTable("Availability");

                entity.Property(e => e.AvailabilityId).HasColumnName("AvailabilityID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndTime).HasDefaultValueSql("('16:00:00.00')");

                entity.Property(e => e.StartTime).HasDefaultValueSql("('08:00:00.00')");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__CountryID__2E1BDC42");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mail).HasMaxLength(50);
            });

            modelBuilder.Entity<DriverInfo>(entity =>
            {
                entity.ToTable("DriverInfo");

                entity.Property(e => e.DriverInfoId).HasColumnName("DriverInfoID");

                entity.Property(e => e.DriverLicenseImage)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EuqualificationExperationDate).HasColumnName("EUQualificationExperationDate");

                entity.Property(e => e.EuqualificationImage)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EUQualificationImage");

                entity.Property(e => e.RouteType).HasMaxLength(100);

                entity.Property(e => e.TruckLicenseImage)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DriverInfos)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverInf__TypeI__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DriverInfos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverInf__UserI__412EB0B6");
            });

            modelBuilder.Entity<DriverLicense>(entity =>
            {
                entity.HasKey(e => new { e.DriverId, e.TypeId })
                    .HasName("PK__DriverLi__B4A73D1D7CECB8AD");

                entity.ToTable("DriverLicense");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.DriverLicenses)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverLic__Drive__4F7CD00D");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DriverLicenses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DriverLic__TypeI__5070F446");
            });

            modelBuilder.Entity<LicenseType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__LicenseT__516F0395EABB3AED");

                entity.ToTable("LicenseType");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Read)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiverUserId).HasColumnName("ReceiverUserID");

                entity.Property(e => e.SenderUserId).HasColumnName("SenderUserID");

                entity.HasOne(d => d.ReceiverUser)
                    .WithMany(p => p.MessageReceiverUsers)
                    .HasForeignKey(d => d.ReceiverUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Receive__44FF419A");

                entity.HasOne(d => d.SenderUser)
                    .WithMany(p => p.MessageSenderUsers)
                    .HasForeignKey(d => d.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__SenderU__45F365D3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("RoleID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__User__AddressID__35BCFE0A");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__Department__33D4B598");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleID__34C8D9D1");
            });

            modelBuilder.Entity<UserAvailability>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AvailabilityId })
                    .HasName("PK__UserAvai__1A2B5B357EA3D80A");

                entity.ToTable("UserAvailability");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AvailabilityId).HasColumnName("AvailabilityID");

                entity.HasOne(d => d.Availability)
                    .WithMany(p => p.UserAvailabilities)
                    .HasForeignKey(d => d.AvailabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAvail__Avail__3D5E1FD2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAvailabilities)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAvail__UserI__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
