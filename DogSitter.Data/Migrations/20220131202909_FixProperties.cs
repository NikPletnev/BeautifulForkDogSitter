using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class FixProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Orders_OrderId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Sitters_SitterId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Sitters_Customers_CustomerId",
                table: "Sitters");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Sitters_SitterId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_SitterId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_Sitters_CustomerId",
                table: "Sitters");

            migrationBuilder.DropIndex(
                name: "IX_Services_OrderId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_SitterId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Sitters");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypeId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerSitter",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    SitterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSitter", x => new { x.CustomersId, x.SitterId });
                    table.ForeignKey(
                        name: "FK_CustomerSitter_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSitter_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderServiсe",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ServiceICollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServiсe", x => new { x.OrdersId, x.ServiceICollectionId });
                    table.ForeignKey(
                        name: "FK_OrderServiсe_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderServiсe_Services_ServiceICollectionId",
                        column: x => x.ServiceICollectionId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiсeSitter",
                columns: table => new
                {
                    ServiceICollectionId = table.Column<int>(type: "int", nullable: false),
                    SittersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiсeSitter", x => new { x.ServiceICollectionId, x.SittersId });
                    table.ForeignKey(
                        name: "FK_ServiсeSitter_Services_ServiceICollectionId",
                        column: x => x.ServiceICollectionId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiсeSitter_Sitters_SittersId",
                        column: x => x.SittersId,
                        principalTable: "Sitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SitterWorkTime",
                columns: table => new
                {
                    SitterId = table.Column<int>(type: "int", nullable: false),
                    WorkTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitterWorkTime", x => new { x.SitterId, x.WorkTimeId });
                    table.ForeignKey(
                        name: "FK_SitterWorkTime_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SitterWorkTime_WorkTimes_WorkTimeId",
                        column: x => x.WorkTimeId,
                        principalTable: "WorkTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSitter_SitterId",
                table: "CustomerSitter",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiсe_ServiceICollectionId",
                table: "OrderServiсe",
                column: "ServiceICollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiсeSitter_SittersId",
                table: "ServiсeSitter",
                column: "SittersId");

            migrationBuilder.CreateIndex(
                name: "IX_SitterWorkTime_WorkTimeId",
                table: "SitterWorkTime",
                column: "WorkTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts",
                column: "ContactTypeId",
                principalTable: "ContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "CustomerSitter");

            migrationBuilder.DropTable(
                name: "OrderServiсe");

            migrationBuilder.DropTable(
                name: "ServiсeSitter");

            migrationBuilder.DropTable(
                name: "SitterWorkTime");

            migrationBuilder.AddColumn<int>(
                name: "SitterId",
                table: "WorkTimes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Sitters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SitterId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContactTypeId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_SitterId",
                table: "WorkTimes",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_CustomerId",
                table: "Sitters",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OrderId",
                table: "Services",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SitterId",
                table: "Services",
                column: "SitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactTypes_ContactTypeId",
                table: "Contacts",
                column: "ContactTypeId",
                principalTable: "ContactTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Orders_OrderId",
                table: "Services",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Sitters_SitterId",
                table: "Services",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sitters_Customers_CustomerId",
                table: "Sitters",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Sitters_SitterId",
                table: "WorkTimes",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");
        }
    }
}
