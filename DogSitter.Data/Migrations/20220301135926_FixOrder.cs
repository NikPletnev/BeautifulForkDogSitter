using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class FixOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBusy",
                table: "WorkTimes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "SitterId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBusy",
                table: "WorkTimes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SitterId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
