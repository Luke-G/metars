using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metars.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    StationIcao = table.Column<string>(type: "text", nullable: false),
                    ObservationTime = table.Column<string>(type: "text", nullable: true),
                    WindDirectionDegrees = table.Column<double>(type: "double precision", nullable: false),
                    WindSpeedKnots = table.Column<double>(type: "double precision", nullable: false),
                    WindGustKnots = table.Column<double>(type: "double precision", nullable: false),
                    Visibility = table.Column<double>(type: "double precision", nullable: true),
                    AltimeterInHg = table.Column<double>(type: "double precision", nullable: true),
                    FlightCategory = table.Column<string>(type: "text", nullable: true),
                    TempC = table.Column<double>(type: "double precision", nullable: true),
                    DewpointC = table.Column<double>(type: "double precision", nullable: true),
                    CloudBaseFeetAglLayer1 = table.Column<int>(type: "integer", nullable: true),
                    SkyCoverLayer1 = table.Column<string>(type: "text", nullable: true),
                    CloudBaseFeetAglLayer2 = table.Column<int>(type: "integer", nullable: true),
                    SkyCoverLayer2 = table.Column<string>(type: "text", nullable: true),
                    CloudBaseFeetAglLayer3 = table.Column<int>(type: "integer", nullable: true),
                    SkyCoverLayer3 = table.Column<string>(type: "text", nullable: true),
                    CloudBaseFeetAglLayer4 = table.Column<int>(type: "integer", nullable: true),
                    SkyCoverLayer4 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metars");
        }
    }
}
