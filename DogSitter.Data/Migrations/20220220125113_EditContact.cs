using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class EditContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Admins_AdminId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Customers_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Sitters_SitterId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AdminId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "SitterId",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_SitterId",
                table: "Contacts",
                newName: "IX_Contacts_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "SitterId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                newName: "IX_Contacts_SitterId");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AdminId",
                table: "Contacts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Admins_AdminId",
                table: "Contacts",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Customers_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Sitters_SitterId",
                table: "Contacts",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id");
        }
    }
}
