using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class subwaystation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubwayStations_Addresses_AddressId",
                table: "SubwayStations");

            migrationBuilder.DropIndex(
                name: "IX_SubwayStations_AddressId",
                table: "SubwayStations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "SubwayStations");

            migrationBuilder.CreateTable(
                name: "AddressSubwayStation",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    SubwayStationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressSubwayStation", x => new { x.AddressesId, x.SubwayStationsId });
                    table.ForeignKey(
                        name: "FK_AddressSubwayStation_Addresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressSubwayStation_SubwayStations_SubwayStationsId",
                        column: x => x.SubwayStationsId,
                        principalTable: "SubwayStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressSubwayStation_SubwayStationsId",
                table: "AddressSubwayStation",
                column: "SubwayStationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressSubwayStation");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "SubwayStations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubwayStations_AddressId",
                table: "SubwayStations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubwayStations_Addresses_AddressId",
                table: "SubwayStations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
