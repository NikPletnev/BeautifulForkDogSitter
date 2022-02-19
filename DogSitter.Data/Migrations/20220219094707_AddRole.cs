using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dogs_DogsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sitters_Addresses_AddressId",
                table: "Sitters");

            migrationBuilder.DropTable(
                name: "AddressCustomer");

            migrationBuilder.DropTable(
                name: "AddressSubwayStation");

            migrationBuilder.DropIndex(
                name: "IX_Sitters_AddressId",
                table: "Sitters");

            migrationBuilder.RenameColumn(
                name: "Weekdays",
                table: "WorkTimes",
                newName: "Weekday");

            migrationBuilder.RenameColumn(
                name: "DogsId",
                table: "Orders",
                newName: "DogId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DogsId",
                table: "Orders",
                newName: "IX_Orders_DogId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "SubwayStations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Sitters",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "SubwayStationId",
                table: "Sitters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Sitters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SitterId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubwayStations_AddressId",
                table: "SubwayStations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_SubwayStationId",
                table: "Sitters",
                column: "SubwayStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SitterId",
                table: "Addresses",
                column: "SitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Sitters_SitterId",
                table: "Addresses",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dogs_DogId",
                table: "Orders",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sitters_SubwayStations_SubwayStationId",
                table: "Sitters",
                column: "SubwayStationId",
                principalTable: "SubwayStations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubwayStations_Addresses_AddressId",
                table: "SubwayStations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Sitters_SitterId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dogs_DogId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sitters_SubwayStations_SubwayStationId",
                table: "Sitters");

            migrationBuilder.DropForeignKey(
                name: "FK_SubwayStations_Addresses_AddressId",
                table: "SubwayStations");

            migrationBuilder.DropIndex(
                name: "IX_SubwayStations_AddressId",
                table: "SubwayStations");

            migrationBuilder.DropIndex(
                name: "IX_Sitters_SubwayStationId",
                table: "Sitters");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_SitterId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "SubwayStations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Sitters");

            migrationBuilder.DropColumn(
                name: "SubwayStationId",
                table: "Sitters");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Sitters");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Weekday",
                table: "WorkTimes",
                newName: "Weekdays");

            migrationBuilder.RenameColumn(
                name: "DogId",
                table: "Orders",
                newName: "DogsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DogId",
                table: "Orders",
                newName: "IX_Orders_DogsId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateTable(
                name: "AddressCustomer",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomer", x => new { x.AddressId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_AddressCustomer_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressSubwayStation",
                columns: table => new
                {
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    SubwayStationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressSubwayStation", x => new { x.AdressId, x.SubwayStationsId });
                    table.ForeignKey(
                        name: "FK_AddressSubwayStation_Addresses_AdressId",
                        column: x => x.AdressId,
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
                name: "IX_Sitters_AddressId",
                table: "Sitters",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomer_CustomersId",
                table: "AddressCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressSubwayStation_SubwayStationsId",
                table: "AddressSubwayStation",
                column: "SubwayStationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dogs_DogsId",
                table: "Orders",
                column: "DogsId",
                principalTable: "Dogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sitters_Addresses_AddressId",
                table: "Sitters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
