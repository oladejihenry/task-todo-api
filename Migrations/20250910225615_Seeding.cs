using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskCrud.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 23, 56, 15, 427, DateTimeKind.Local).AddTicks(5310), null, "Test", new DateTime(2025, 9, 10, 23, 56, 15, 438, DateTimeKind.Local).AddTicks(420) },
                    { 2, new DateTime(2025, 9, 10, 23, 56, 15, 438, DateTimeKind.Local).AddTicks(630), null, "Test", new DateTime(2025, 9, 10, 23, 56, 15, 438, DateTimeKind.Local).AddTicks(640) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
