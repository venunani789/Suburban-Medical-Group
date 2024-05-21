using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SububanMedicalGroupSMGWebApp.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "openHours",
                columns: table => new
                {
                    OpenHoursId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hours = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_openHours", x => x.OpenHoursId);
                });

            migrationBuilder.CreateTable(
                name: "PatientRegistrations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MedicalInsurance = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegistrations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    SpecialityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Specialities = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.SpecialityID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressStreet = table.Column<string>(type: "TEXT", nullable: false),
                    AddressTown = table.Column<string>(type: "TEXT", nullable: false),
                    AddressState = table.Column<string>(type: "TEXT", nullable: false),
                    AddressPostCode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OpenHoursId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ClinicId);
                    table.ForeignKey(
                        name: "FK_Clinics_openHours_OpenHoursId",
                        column: x => x.OpenHoursId,
                        principalTable: "openHours",
                        principalColumn: "OpenHoursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Physician",
                columns: table => new
                {
                    PhysicianID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecialityID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClinicId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physician", x => x.PhysicianID);
                    table.ForeignKey(
                        name: "FK_Physician_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Physician_Specialities_SpecialityID",
                        column: x => x.SpecialityID,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 1, "Family medicine" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 2, "Internal medicine" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 3, "Pediatrics" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 4, "Allergy" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 5, "Cardiology" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 6, "Chiropractic" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 7, "Dermatology" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 8, "Diabetes" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 9, "Gastroenterology" });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "SpecialityID", "Specialities" },
                values: new object[] { 10, "Neurology" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 1, "8am–8pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 2, "9am–9pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 3, "8am-4pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 4, "8am-5pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 5, "8am-12pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 6, "9am-1pm" });

            migrationBuilder.InsertData(
                table: "openHours",
                columns: new[] { "OpenHoursId", "Hours" },
                values: new object[] { 7, "Closed" });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "AddressPostCode", "AddressState", "AddressStreet", "AddressTown", "OpenHoursId", "PhoneNumber" },
                values: new object[] { 1, "12345", "CA", "123 Main Street", "Sedona", 2, "+1 (555) 123-4567" });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "AddressPostCode", "AddressState", "AddressStreet", "AddressTown", "OpenHoursId", "PhoneNumber" },
                values: new object[] { 2, "90210", "NY", "123 Main St", "Beaufort", 1, "555-1234" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_OpenHoursId",
                table: "Clinics",
                column: "OpenHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Physician_ClinicId",
                table: "Physician",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Physician_SpecialityID",
                table: "Physician",
                column: "SpecialityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PatientRegistrations");

            migrationBuilder.DropTable(
                name: "Physician");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "openHours");
        }
    }
}
