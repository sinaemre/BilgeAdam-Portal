using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HumanResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserID = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserID = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassroomName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserID = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Exam1 = table.Column<double>(type: "double precision", nullable: true),
                    Exam2 = table.Column<double>(type: "double precision", nullable: true),
                    ProjectExam = table.Column<double>(type: "double precision", nullable: true),
                    ClassroomId = table.Column<int>(type: "integer", nullable: false),
                    ProjectPath = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HumanResources",
                columns: new[] { "Id", "AppUserID", "BirthDate", "CreatedDate", "DeletedDate", "Email", "FirstName", "HireDate", "LastName", "Status", "UpdatedDate" },
                values: new object[] { 1, "1122d035-d752-4629-a593-ce22c8958344", new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7981), null, "hulya.celebi@bilgeadam.com", "Hülya", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Çelebi Yılmaz", 1, null });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AppUserID", "BirthDate", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "Status", "UpdatedDate" },
                values: new object[] { 1, "94d24825-6148-434a-85b4-259de2b77f3d", new DateTime(1996, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7093), null, "sinaemre.bekar@bilgeadam.com", "Sina Emre", "Bekar", 1, null });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "ClassroomName", "CreatedDate", "DeletedDate", "Description", "Status", "TeacherId", "UpdatedDate" },
                values: new object[] { 1, "YZL-8743", new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7460), null, "320 Saat .NET Full Stack Yazılım Uzmanlığı Eğitimi", 1, 1, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AppUserID", "BirthDate", "ClassroomId", "CreatedDate", "DeletedDate", "Email", "Exam1", "Exam2", "FirstName", "LastName", "ProjectExam", "ProjectPath", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9", new DateTime(1994, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7653), null, "aygun.ziya@bilgeadam.com", null, null, "Ziya", "Aygün", null, null, 1, null },
                    { 2, "428e15d3-3141-4cb0-b245-f0201f6929c7", new DateTime(1991, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7660), null, "gokce.sporalagoz@bilgeadam.com", null, null, "Gökçe", "Spor Alagöz", null, null, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_TeacherId",
                table: "Classrooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                column: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanResources");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
