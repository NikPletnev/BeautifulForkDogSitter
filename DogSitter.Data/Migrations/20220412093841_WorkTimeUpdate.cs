using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class WorkTimeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkTimes_SitterWorkTimeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.RenameColumn(
                name: "SitterWorkTimeId",
                table: "Orders",
                newName: "SitterBusyTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SitterWorkTimeId",
                table: "Orders",
                newName: "IX_Orders_SitterBusyTimeId");

            migrationBuilder.CreateTable(
                name: "BusyTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    SitterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusyTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusyTimes_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SitterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusyTimes_SitterId",
                table: "BusyTimes",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_SitterId",
                table: "Timesheets",
                column: "SitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BusyTimes_SitterBusyTimeId",
                table: "Orders",
                column: "SitterBusyTimeId",
                principalTable: "BusyTimes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BusyTimes_SitterBusyTimeId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BusyTimes");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.RenameColumn(
                name: "SitterBusyTimeId",
                table: "Orders",
                newName: "SitterWorkTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SitterBusyTimeId",
                table: "Orders",
                newName: "IX_Orders_SitterWorkTimeId");

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SitterId = table.Column<int>(type: "int", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBusy = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimes_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_SitterId",
                table: "WorkTimes",
                column: "SitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WorkTimes_SitterWorkTimeId",
                table: "Orders",
                column: "SitterWorkTimeId",
                principalTable: "WorkTimes",
                principalColumn: "Id");
        }
    }
}
