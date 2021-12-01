﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webdev_semester_1.Models;

namespace webdev_semester_1.Migrations
{
    [DbContext(typeof(AlexAndersenDBContext))]
    [Migration("20211201090540_AlexAndersenIdentityInit")]
    partial class AlexAndersenIdentityInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Danish_Norwegian_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AddressID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityID");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("CityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AssignmentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AllDay")
                        .HasColumnType("bit");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("ContactUserId")
                        .HasColumnType("int")
                        .HasColumnName("ContactUserID");

                    b.Property<string>("CountryCodeEnd")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CountryCodeStart")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DriverUserId")
                        .HasColumnType("int")
                        .HasColumnName("DriverUserID");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReplacementUserId")
                        .HasColumnType("int")
                        .HasColumnName("ReplacementUserID");

                    b.Property<int>("StartCityId")
                        .HasColumnType("int")
                        .HasColumnName("StartCityID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusID");

                    b.Property<bool?>("Urgent")
                        .HasColumnType("bit");

                    b.HasKey("AssignmentId");

                    b.HasIndex("ContactUserId");

                    b.HasIndex("DriverUserId");

                    b.HasIndex("ReplacementUserId");

                    b.HasIndex("StartCityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AvailabilityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("EndTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasDefaultValueSql("('16:00:00.00')");

                    b.Property<TimeSpan?>("StartTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasDefaultValueSql("('08:00:00.00')");

                    b.HasKey("AvailabilityId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("webdev_semester_1.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CityID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CountryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Phone")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("webdev_semester_1.Models.DriverInfo", b =>
                {
                    b.Property<int>("DriverInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DriverInfoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DriverLicenseExperationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicenseImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DriverLicenseNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("EuqualificationExperationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EUQualificationExperationDate");

                    b.Property<string>("EuqualificationImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EUQualificationImage");

                    b.Property<string>("RouteType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("TruckLicenseExperationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TruckLicenseImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("DriverInfoId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("DriverInfo");
                });

            modelBuilder.Entity("webdev_semester_1.Models.DriverLicense", b =>
                {
                    b.Property<int>("DriverId")
                        .HasColumnType("int")
                        .HasColumnName("DriverID");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.HasKey("DriverId", "TypeId")
                        .HasName("PK__DriverLi__B4A73D1D7CECB8AD");

                    b.HasIndex("TypeId");

                    b.ToTable("DriverLicense");
                });

            modelBuilder.Entity("webdev_semester_1.Models.LicenseType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TypeID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("TypeId")
                        .HasName("PK__LicenseT__516F0395EABB3AED");

                    b.ToTable("LicenseType");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MessageID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("Read")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('0')");

                    b.Property<int>("ReceiverUserId")
                        .HasColumnType("int")
                        .HasColumnName("ReceiverUserID");

                    b.Property<int>("SenderUserId")
                        .HasColumnType("int")
                        .HasColumnName("SenderUserID");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StatusID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("webdev_semester_1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("AddressID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("webdev_semester_1.Models.UserAvailability", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<int>("AvailabilityId")
                        .HasColumnType("int")
                        .HasColumnName("AvailabilityID");

                    b.HasKey("UserId", "AvailabilityId")
                        .HasName("PK__UserAvai__1A2B5B357EA3D80A");

                    b.HasIndex("AvailabilityId");

                    b.ToTable("UserAvailability");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("webdev_semester_1.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("webdev_semester_1.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webdev_semester_1.Models.Address", b =>
                {
                    b.HasOne("webdev_semester_1.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK__Address__CityID__30F848ED")
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Assignment", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", "ContactUser")
                        .WithMany("AssignmentContactUsers")
                        .HasForeignKey("ContactUserId")
                        .HasConstraintName("FK__Assignmen__Conta__4AB81AF0")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", "DriverUser")
                        .WithMany("AssignmentDriverUsers")
                        .HasForeignKey("DriverUserId")
                        .HasConstraintName("FK__Assignmen__Drive__4CA06362")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", "ReplacementUser")
                        .WithMany("AssignmentReplacementUsers")
                        .HasForeignKey("ReplacementUserId")
                        .HasConstraintName("FK__Assignmen__Repla__4BAC3F29");

                    b.HasOne("webdev_semester_1.Models.City", "StartCity")
                        .WithMany("Assignments")
                        .HasForeignKey("StartCityId")
                        .HasConstraintName("FK__Assignmen__Start__49C3F6B7")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.Status", "Status")
                        .WithMany("Assignments")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__Assignmen__Statu__48CFD27E")
                        .IsRequired();

                    b.Navigation("ContactUser");

                    b.Navigation("DriverUser");

                    b.Navigation("ReplacementUser");

                    b.Navigation("StartCity");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("webdev_semester_1.Models.City", b =>
                {
                    b.HasOne("webdev_semester_1.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK__City__CountryID__2E1BDC42")
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("webdev_semester_1.Models.DriverInfo", b =>
                {
                    b.HasOne("webdev_semester_1.Models.LicenseType", "Type")
                        .WithMany("DriverInfos")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__DriverInf__TypeI__403A8C7D")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", "User")
                        .WithMany("DriverInfos")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__DriverInf__UserI__412EB0B6")
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webdev_semester_1.Models.DriverLicense", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", "Driver")
                        .WithMany("DriverLicenses")
                        .HasForeignKey("DriverId")
                        .HasConstraintName("FK__DriverLic__Drive__4F7CD00D")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.LicenseType", "Type")
                        .WithMany("DriverLicenses")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__DriverLic__TypeI__5070F446")
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Message", b =>
                {
                    b.HasOne("webdev_semester_1.Models.User", "ReceiverUser")
                        .WithMany("MessageReceiverUsers")
                        .HasForeignKey("ReceiverUserId")
                        .HasConstraintName("FK__Message__Receive__44FF419A")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", "SenderUser")
                        .WithMany("MessageSenderUsers")
                        .HasForeignKey("SenderUserId")
                        .HasConstraintName("FK__Message__SenderU__45F365D3")
                        .IsRequired();

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("webdev_semester_1.Models.User", b =>
                {
                    b.HasOne("webdev_semester_1.Models.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK__User__AddressID__35BCFE0A");

                    b.HasOne("webdev_semester_1.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__User__Department__33D4B598")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__RoleID__34C8D9D1")
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("webdev_semester_1.Models.UserAvailability", b =>
                {
                    b.HasOne("webdev_semester_1.Models.Availability", "Availability")
                        .WithMany("UserAvailabilities")
                        .HasForeignKey("AvailabilityId")
                        .HasConstraintName("FK__UserAvail__Avail__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("webdev_semester_1.Models.User", "User")
                        .WithMany("UserAvailabilities")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserAvail__UserI__3C69FB99")
                        .IsRequired();

                    b.Navigation("Availability");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Address", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Availability", b =>
                {
                    b.Navigation("UserAvailabilities");
                });

            modelBuilder.Entity("webdev_semester_1.Models.City", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("webdev_semester_1.Models.LicenseType", b =>
                {
                    b.Navigation("DriverInfos");

                    b.Navigation("DriverLicenses");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("webdev_semester_1.Models.Status", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("webdev_semester_1.Models.User", b =>
                {
                    b.Navigation("AssignmentContactUsers");

                    b.Navigation("AssignmentDriverUsers");

                    b.Navigation("AssignmentReplacementUsers");

                    b.Navigation("DriverInfos");

                    b.Navigation("DriverLicenses");

                    b.Navigation("MessageReceiverUsers");

                    b.Navigation("MessageSenderUsers");

                    b.Navigation("UserAvailabilities");
                });
#pragma warning restore 612, 618
        }
    }
}
