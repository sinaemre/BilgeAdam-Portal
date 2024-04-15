using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.IdentityContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LoginCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5", null, "admin", "ADMIN" },
                    { "2b5d6dba-dba7-4c5d-a24b-16119815bf87", null, "humanResources", "HUMANRESOURCES" },
                    { "637e750e-4772-414e-be79-8df14420f11e", null, "student", "STUDENT" },
                    { "ad02f608-b3f5-43e8-aac6-6f5d8900d493", null, "teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "LoginCount", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9", 0, new DateTime(1994, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "7551b6b1-a606-413b-8474-fe09de0056b9", new DateTime(2024, 4, 2, 13, 57, 41, 802, DateTimeKind.Local).AddTicks(247), null, "aygun.ziya@bilgeadam.com", false, "Ziya", "Aygün", false, null, 0, "AYGUN.ZIYA@BILGEADAM.COM", "ZIYA.AYGUN", "AQAAAAIAAYagAAAAEJfXELbE0Wb4dQ4S06vkK74U1MTLj6rxEWLrN07eGOO1gBN5Vu1//9K7kSca04vhOw==", null, false, "30bfe208-6c51-4a2c-b61a-0ae1b06527c2", 1, false, null, "ziya.aygun" },
                    { "1122d035-d752-4629-a593-ce22c8958344", 0, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ef10ef38-336f-495c-bde4-c4af422cb920", new DateTime(2024, 4, 2, 13, 57, 41, 538, DateTimeKind.Local).AddTicks(6629), null, "hulya.celebi@bilgeadam.com", false, "Hülya", "Çelebi Yılmaz", false, null, 0, "HULYA.CELEBI@BILGEADAM.COM", "HULYA.CELEBI", "AQAAAAIAAYagAAAAEMWUBcIGOPg5E4n2cC3tG3X0tyXAAxwetgSeXLTtbj7dPcJ7wJooVWFM3RHRYKbtTA==", null, false, "dca3d199-23b2-46c0-9438-613e7c8e3e3d", 1, false, null, "hulya.celebi" },
                    { "371caecc-777f-4249-8c7d-bbb3f27a73b8", 0, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fcdc437f-f3c9-480a-a86c-b3d570105008", new DateTime(2024, 4, 2, 13, 57, 41, 420, DateTimeKind.Local).AddTicks(5876), null, "admin@bilgeadam.com", false, "Yönetici", "Admin", false, null, 0, "ADMIN@BILGEADAM.COM", "ADMIN", "AQAAAAIAAYagAAAAED/UU0Hu7U/OyAOg3vyTPYu/MFTK6fhGdfVw+dD9BBD0Wi3vNKe+kpd/q/Of/kw1vA==", null, false, "722a2b70-1ec9-4ae2-af3d-8b58068ba0d8", 1, false, null, "admin" },
                    { "428e15d3-3141-4cb0-b245-f0201f6929c7", 0, new DateTime(1991, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "29c19cc3-bcf2-4a87-a59d-e9dd219575f1", new DateTime(2024, 4, 2, 13, 57, 41, 933, DateTimeKind.Local).AddTicks(1122), null, "gokce.sporalagoz@bilgeadam.com", false, "Gökçe", "Spor Alagöz", false, null, 0, "GOKCE.SPORALAGOZ@BILGEADAM.COM", "GOKCE.SPORALAGOZ", "AQAAAAIAAYagAAAAEG2/U31aOgOQMQj0xm3WOQrMhWRHKWdWhY0dW7mVHTh/SU5Ec16hF9LUCAxX2L0KnA==", null, false, "dd4f7a74-da6d-4209-bf20-2d65f33dcb4c", 1, false, null, "gokce.sporalagoz" },
                    { "94d24825-6148-434a-85b4-259de2b77f3d", 0, new DateTime(1996, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "e6ba60f2-aa5b-4c49-85e4-fd7455c0e665", new DateTime(2024, 4, 2, 13, 57, 41, 680, DateTimeKind.Local).AddTicks(202), null, "sinaemre.bekar@bilgeadam.com", false, "Sina Emre", "Bekar", false, null, 0, "SINAEMRE.BEKAR@BILGEADAM.COM", "SINAEMRE.BEKAR", "AQAAAAIAAYagAAAAELnXVNgA+h/cEFOSxkB81Qt74JZDjqf63UgDI+iSr2miV+TTc795h2Hqbv1NCsdTUQ==", null, false, "35424aa3-52ea-4f0d-88b4-b4477c3ff358", 1, false, null, "sinaemre.bekar" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "637e750e-4772-414e-be79-8df14420f11e", "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9" },
                    { "2b5d6dba-dba7-4c5d-a24b-16119815bf87", "1122d035-d752-4629-a593-ce22c8958344" },
                    { "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5", "371caecc-777f-4249-8c7d-bbb3f27a73b8" },
                    { "637e750e-4772-414e-be79-8df14420f11e", "428e15d3-3141-4cb0-b245-f0201f6929c7" },
                    { "ad02f608-b3f5-43e8-aac6-6f5d8900d493", "94d24825-6148-434a-85b4-259de2b77f3d" }
                });

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
        }

        /// <inheritdoc />
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
