using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webdev_semester_1.Models
{
    public partial class AlexAndersenDBContext : DbContext
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
        public virtual DbSet<ChauffeurInfo> ChauffeurInfos { get; set; }
        public virtual DbSet<ChauffeurLicense> ChauffeurLicenses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<LicenseType> LicenseTypes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7CKEKRSF\\SQLEXPRESS;Database=AlexAndersenDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.Property(e => e.ChauffeurId).HasColumnName("ChauffeurID");

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

                entity.Property(e => e.ReplacementUserId).HasColumnName("ReplacementUserID");

                entity.Property(e => e.StartCityId).HasColumnName("StartCityID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Chauffeur)
                    .WithMany(p => p.AssignmentChauffeurs)
                    .HasForeignKey(d => d.ChauffeurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Chauf__440B1D61");

                entity.HasOne(d => d.ContactUser)
                    .WithMany(p => p.AssignmentContactUsers)
                    .HasForeignKey(d => d.ContactUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Conta__4222D4EF");

                entity.HasOne(d => d.ReplacementUser)
                    .WithMany(p => p.AssignmentReplacementUsers)
                    .HasForeignKey(d => d.ReplacementUserId)
                    .HasConstraintName("FK__Assignmen__Repla__4316F928");

                entity.HasOne(d => d.StartCity)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.StartCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Start__412EB0B6");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Statu__403A8C7D");
            });

            modelBuilder.Entity<ChauffeurInfo>(entity =>
            {
                entity.ToTable("ChauffeurInfo");

                entity.Property(e => e.ChauffeurInfoId).HasColumnName("ChauffeurInfoID");

                entity.Property(e => e.DriverLicenseImage)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RouteType).HasMaxLength(100);

                entity.Property(e => e.TruckLicenseImage).HasMaxLength(100);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ChauffeurInfos)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chauffeur__TypeI__33D4B598");
            });

            modelBuilder.Entity<ChauffeurLicense>(entity =>
            {
                entity.HasKey(e => new { e.ChauffeurId, e.TypeId })
                    .HasName("PK__Chauffeu__10CC532D867F656A");

                entity.ToTable("ChauffeurLicense");

                entity.Property(e => e.ChauffeurId).HasColumnName("ChauffeurID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Chauffeur)
                    .WithMany(p => p.ChauffeurLicenses)
                    .HasForeignKey(d => d.ChauffeurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chauffeur__Chauf__46E78A0C");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ChauffeurLicenses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chauffeur__TypeI__47DBAE45");
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

            modelBuilder.Entity<LicenseType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__LicenseT__516F039579E2F868");

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

                entity.Property(e => e.ReceiverUserId).HasColumnName("ReceiverUserID");

                entity.Property(e => e.SenderUserId).HasColumnName("SenderUserID");

                entity.HasOne(d => d.ReceiverUser)
                    .WithMany(p => p.MessageReceiverUsers)
                    .HasForeignKey(d => d.ReceiverUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Receive__3C69FB99");

                entity.HasOne(d => d.SenderUser)
                    .WithMany(p => p.MessageSenderUsers)
                    .HasForeignKey(d => d.SenderUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__SenderU__3D5E1FD2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
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

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ChauffeurInfoId).HasColumnName("ChauffeurInfoID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__User__AddressID__38996AB5");

                entity.HasOne(d => d.ChauffeurInfo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ChauffeurInfoId)
                    .HasConstraintName("FK__User__ChauffeurI__398D8EEE");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__User__Department__36B12243");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleID__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
