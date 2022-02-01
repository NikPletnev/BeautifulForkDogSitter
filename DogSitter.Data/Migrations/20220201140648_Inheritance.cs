using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_Customers_CustomersId",
                table: "AddressCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Admins_AdminId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Customers_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Sitters_SitterId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSitter_Customers_CustomersId",
                table: "CustomerSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSitter_Sitters_SitterId",
                table: "CustomerSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiсeSitter_Sitters_SittersId",
                table: "ServiсeSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_Sitters_Addresses_AddressId",
                table: "Sitters");

            migrationBuilder.DropForeignKey(
                name: "FK_Sitters_Passports_PassportId",
                table: "Sitters");

            migrationBuilder.DropForeignKey(
                name: "FK_SitterWorkTime_Sitters_SitterId",
                table: "SitterWorkTime");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sitters",
                table: "Sitters");

            migrationBuilder.DropIndex(
                name: "IX_Sitters_PassportId",
                table: "Sitters");

            migrationBuilder.RenameTable(
                name: "Sitters",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Sitters_AddressId",
                table: "Users",
                newName: "IX_Users_AddressId");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PassportId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PassportId",
                table: "Users",
                column: "PassportId",
                unique: true,
                filter: "[PassportId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_Users_CustomersId",
                table: "AddressCustomer",
                column: "CustomersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_AdminId",
                table: "Contacts",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_CustomerId",
                table: "Contacts",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_SitterId",
                table: "Contacts",
                column: "SitterId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSitter_Users_CustomersId",
                table: "CustomerSitter",
                column: "CustomersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSitter_Users_SitterId",
                table: "CustomerSitter",
                column: "SitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Users_CustomerId",
                table: "Dogs",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_SitterId",
                table: "Orders",
                column: "SitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiсeSitter_Users_SittersId",
                table: "ServiсeSitter",
                column: "SittersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SitterWorkTime_Users_SitterId",
                table: "SitterWorkTime",
                column: "SitterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passports_PassportId",
                table: "Users",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_Users_CustomersId",
                table: "AddressCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_AdminId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_CustomerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_SitterId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSitter_Users_CustomersId",
                table: "CustomerSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSitter_Users_SitterId",
                table: "CustomerSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Users_CustomerId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_SitterId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiсeSitter_Users_SittersId",
                table: "ServiсeSitter");

            migrationBuilder.DropForeignKey(
                name: "FK_SitterWorkTime_Users_SitterId",
                table: "SitterWorkTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passports_PassportId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PassportId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Sitters");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressId",
                table: "Sitters",
                newName: "IX_Sitters_AddressId");

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Sitters",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassportId",
                table: "Sitters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Sitters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sitters",
                table: "Sitters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_PassportId",
                table: "Sitters",
                column: "PassportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_Customers_CustomersId",
                table: "AddressCustomer",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSitter_Customers_CustomersId",
                table: "CustomerSitter",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSitter_Sitters_SitterId",
                table: "CustomerSitter",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Customers_CustomerId",
                table: "Dogs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sitters_SitterId",
                table: "Orders",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiсeSitter_Sitters_SittersId",
                table: "ServiсeSitter",
                column: "SittersId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sitters_Addresses_AddressId",
                table: "Sitters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sitters_Passports_PassportId",
                table: "Sitters",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SitterWorkTime_Sitters_SitterId",
                table: "SitterWorkTime",
                column: "SitterId",
                principalTable: "Sitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
