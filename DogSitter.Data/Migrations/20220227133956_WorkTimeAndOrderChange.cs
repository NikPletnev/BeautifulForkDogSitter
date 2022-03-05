using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class WorkTimeAndOrderChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "WorkTimes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SitterWorkTimeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SitterWorkTimeId",
                table: "Orders",
                column: "SitterWorkTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WorkTimes_SitterWorkTimeId",
                table: "Orders",
                column: "SitterWorkTimeId",
                principalTable: "WorkTimes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WorkTimes_SitterWorkTimeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SitterWorkTimeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "SitterWorkTimeId",
                table: "Orders");
        }
    }
}
