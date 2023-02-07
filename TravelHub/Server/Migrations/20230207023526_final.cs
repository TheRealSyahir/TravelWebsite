using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHub.Server.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivitySelection",
                keyColumn: "ActivitySelectionID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 7, 10, 35, 25, 213, DateTimeKind.Local).AddTicks(9985));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivitySelection",
                keyColumn: "ActivitySelectionID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 6, 15, 9, 25, 227, DateTimeKind.Local).AddTicks(8495));
        }
    }
}
