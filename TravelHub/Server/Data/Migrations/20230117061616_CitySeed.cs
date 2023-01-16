using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelHub.Server.Data.Migrations
{
    public partial class CitySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Safety = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Countryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "Countryname", "Name", "Safety", "Transport" },
                values: new object[] { 1, "Singapore", "Singapore", 5, "Accessible" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "Countryname", "Name", "Safety", "Transport" },
                values: new object[] { 2, "England", "London", 3, "Accessible" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
