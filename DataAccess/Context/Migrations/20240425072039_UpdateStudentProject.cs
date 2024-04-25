using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 10, 20, 37, 783, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "HumanResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 10, 20, 37, 784, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ProjectName" },
                values: new object[] { new DateTime(2024, 4, 25, 10, 20, 37, 784, DateTimeKind.Local).AddTicks(60), null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ProjectName" },
                values: new object[] { new DateTime(2024, 4, 25, 10, 20, 37, 784, DateTimeKind.Local).AddTicks(65), null });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 25, 10, 20, 37, 783, DateTimeKind.Local).AddTicks(9502));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "HumanResources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 4, 2, 13, 47, 57, 257, DateTimeKind.Local).AddTicks(7093));
        }
    }
}
