using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class AddUserinheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SitterId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_SitterId",
                table: "WorkTimes",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SitterId",
                table: "Services",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Value",
                table: "Contacts",
                column: "Value",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Sitters_SitterId",
                table: "Services",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Sitters_SitterId",
                table: "WorkTimes",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Sitters_SitterId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Sitters_SitterId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_SitterId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_Services_SitterId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Value",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "WorkTimes");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "Services");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ServiсeSitter",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    SittersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiсeSitter", x => new { x.ServicesId, x.SittersId });
                    table.ForeignKey(
                        name: "FK_ServiсeSitter_Services_ServicesId",
                        column: x => x.ServicesId,
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
                name: "IX_ServiсeSitter_SittersId",
                table: "ServiсeSitter",
                column: "SittersId");

            migrationBuilder.CreateIndex(
                name: "IX_SitterWorkTime_WorkTimeId",
                table: "SitterWorkTime",
                column: "WorkTimeId");
        }
    }
}
