using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SububanMedicalGroupSMGWebApp.Models.DomainModels;

namespace SububanMedicalGroupSMGWebApp.Models.DataLayer
{
    public class SMGWebAppContext : IdentityDbContext<User>
    {
        public SMGWebAppContext(DbContextOptions<SMGWebAppContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Speciality> Specialities { get; set; } = null!;
        public DbSet<Physician> Physician { get; set; } = null!;
        public DbSet<Clinic> Clinics { get; set; } = null!;
        public DbSet<OpenHours> openHours { get; set; } = null!;
        public DbSet<PatientRegistration> PatientRegistrations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OpenHours>().HasData(
               new OpenHours { OpenHoursId = 1, Hours = "8am–8pm" },
               new OpenHours { OpenHoursId = 2, Hours = "9am–9pm" },
               new OpenHours { OpenHoursId = 3, Hours = "8am-4pm" },
               new OpenHours { OpenHoursId = 4, Hours = "8am-5pm" },
               new OpenHours { OpenHoursId = 5, Hours = "8am-12pm" },
               new OpenHours { OpenHoursId = 6, Hours = "9am-1pm" },
               new OpenHours { OpenHoursId = 7, Hours = "Closed" }
           );

            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    ClinicId = 1,
                    OpenHoursId = 2,
                    AddressStreet = "123 Main Street",
                    AddressTown = "Sedona",
                    AddressState = "CA",
                    AddressPostCode = "12345",
                    PhoneNumber = "+1 (555) 123-4567"
                },
                new Clinic
                {
                    ClinicId = 2,
                    OpenHoursId = 1,
                    AddressStreet = "123 Main St",
                    AddressTown = "Beaufort",
                    AddressState = "NY",
                    AddressPostCode = "90210",
                    PhoneNumber = "555-1234"
                }
            );

            //modelBuilder.Entity<Physician>().HasData(
            //    new Physician
            //    {
            //        PhysicianID = 1,
            //        SpecialityID = 8,
            //        FirstName = "Thomas",
            //        LastName = "Williams",
            //        DateofBirth = new DateTime(1999, 03, 21),
            //        Gender = "Male",
            //        Language = "English",
            //        ClinicId = 1,
            //    },
            //    new Physician
            //    {
            //        PhysicianID = 2,
            //        SpecialityID = 4,
            //        FirstName = "Skyler",
            //        LastName = "Gasvo",
            //        DateofBirth = new DateTime(2006, 12, 19),
            //        Gender = "Female",
            //        Language = "English",
            //        ClinicId = 1,
            //    }
            //);




            modelBuilder.Entity<Speciality>().HasData(
               new Speciality { SpecialityID = 1, Specialities = "Family medicine" },
               new Speciality { SpecialityID = 2, Specialities = "Internal medicine" },
               new Speciality { SpecialityID = 3, Specialities = "Pediatrics" },
               new Speciality { SpecialityID = 4, Specialities = "Allergy" },
               new Speciality { SpecialityID = 5, Specialities = "Cardiology" },
               new Speciality { SpecialityID = 6, Specialities = "Chiropractic" },
               new Speciality { SpecialityID = 7, Specialities = "Dermatology" },
               new Speciality { SpecialityID = 8, Specialities = "Diabetes" },
               new Speciality { SpecialityID = 9, Specialities = "Gastroenterology" },
               new Speciality { SpecialityID = 10, Specialities = "Neurology" }
           );
        }
    }
}
