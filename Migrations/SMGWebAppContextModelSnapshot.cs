﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SububanMedicalGroupSMGWebApp.Models.DataLayer;

#nullable disable

namespace SububanMedicalGroupSMGWebApp.Migrations
{
    [DbContext(typeof(SMGWebAppContext))]
    partial class SMGWebAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressPostCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressState")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressStreet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressTown")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OpenHoursId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClinicId");

                    b.HasIndex("OpenHoursId");

                    b.ToTable("Clinics");

                    b.HasData(
                        new
                        {
                            ClinicId = 1,
                            AddressPostCode = "12345",
                            AddressState = "CA",
                            AddressStreet = "123 Main Street",
                            AddressTown = "Sedona",
                            OpenHoursId = 2,
                            PhoneNumber = "+1 (555) 123-4567"
                        },
                        new
                        {
                            ClinicId = 2,
                            AddressPostCode = "90210",
                            AddressState = "NY",
                            AddressStreet = "123 Main St",
                            AddressTown = "Beaufort",
                            OpenHoursId = 1,
                            PhoneNumber = "555-1234"
                        });
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.OpenHours", b =>
                {
                    b.Property<int>("OpenHoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hours")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OpenHoursId");

                    b.ToTable("openHours");

                    b.HasData(
                        new
                        {
                            OpenHoursId = 1,
                            Hours = "8am–8pm"
                        },
                        new
                        {
                            OpenHoursId = 2,
                            Hours = "9am–9pm"
                        },
                        new
                        {
                            OpenHoursId = 3,
                            Hours = "8am-4pm"
                        },
                        new
                        {
                            OpenHoursId = 4,
                            Hours = "8am-5pm"
                        },
                        new
                        {
                            OpenHoursId = 5,
                            Hours = "8am-12pm"
                        },
                        new
                        {
                            OpenHoursId = 6,
                            Hours = "9am-1pm"
                        },
                        new
                        {
                            OpenHoursId = 7,
                            Hours = "Closed"
                        });
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.PatientRegistration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DOB")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MedicalInsurance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("PatientRegistrations");
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.Physician", b =>
                {
                    b.Property<int>("PhysicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClinicId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialityID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PhysicianID");

                    b.HasIndex("ClinicId");

                    b.HasIndex("SpecialityID");

                    b.ToTable("Physician");
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.Speciality", b =>
                {
                    b.Property<int>("SpecialityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Specialities")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialityID");

                    b.ToTable("Specialities");

                    b.HasData(
                        new
                        {
                            SpecialityID = 1,
                            Specialities = "Family medicine"
                        },
                        new
                        {
                            SpecialityID = 2,
                            Specialities = "Internal medicine"
                        },
                        new
                        {
                            SpecialityID = 3,
                            Specialities = "Pediatrics"
                        },
                        new
                        {
                            SpecialityID = 4,
                            Specialities = "Allergy"
                        },
                        new
                        {
                            SpecialityID = 5,
                            Specialities = "Cardiology"
                        },
                        new
                        {
                            SpecialityID = 6,
                            Specialities = "Chiropractic"
                        },
                        new
                        {
                            SpecialityID = 7,
                            Specialities = "Dermatology"
                        },
                        new
                        {
                            SpecialityID = 8,
                            Specialities = "Diabetes"
                        },
                        new
                        {
                            SpecialityID = 9,
                            Specialities = "Gastroenterology"
                        },
                        new
                        {
                            SpecialityID = 10,
                            Specialities = "Neurology"
                        });
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.Clinic", b =>
                {
                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.OpenHours", "OpenHours")
                        .WithMany()
                        .HasForeignKey("OpenHoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OpenHours");
                });

            modelBuilder.Entity("SububanMedicalGroupSMGWebApp.Models.DomainModels.Physician", b =>
                {
                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SububanMedicalGroupSMGWebApp.Models.DomainModels.Speciality", "Specialities")
                        .WithMany()
                        .HasForeignKey("SpecialityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Specialities");
                });
#pragma warning restore 612, 618
        }
    }
}
