using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class FixPropertiesAndAddSubway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Orders_OrderId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiсe_Services_ServiceICollectionId",
                table: "OrderServiсe");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_OrderId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Dogs");

            migrationBuilder.RenameColumn(
                name: "ServiceICollectionId",
                table: "OrderServiсe",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServiсe_ServiceICollectionId",
                table: "OrderServiсe",
                newName: "IX_OrderServiсe_ServiceId");

            migrationBuilder.AlterColumn<int>(
                name: "House",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Apartament",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DogOrder",
                columns: table => new
                {
                    DogsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogOrder", x => new { x.DogsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DogOrder_Dogs_DogsId",
                        column: x => x.DogsId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubwayStations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Девяткино" },
                    { 2, "Гражданский проспект" },
                    { 3, "Академическая" },
                    { 4, "Политехническая" },
                    { 5, "Площадь Мужества" },
                    { 6, "Лесная" },
                    { 7, "Выборгская" },
                    { 8, "Площадь Ленина" },
                    { 9, "Чернышевская" },
                    { 10, "Площадь Восстания" },
                    { 11, "Владимирская" },
                    { 12, "Пушкинская" },
                    { 13, "Технологический институт(1)" },
                    { 14, "Балтийская" },
                    { 15, "Нарвская" },
                    { 16, "Кировский завод" },
                    { 17, "Автово" },
                    { 18, "Ленинский проспект" },
                    { 19, "Проспект Ветеранов" },
                    { 20, "Парнас" },
                    { 21, "Проспект Просвещения" },
                    { 22, "Озерки" },
                    { 23, "Удельная" },
                    { 24, "Пионерская" },
                    { 25, "Чёрная речка" },
                    { 26, "Петроградская" },
                    { 27, "Горьковская" },
                    { 28, "Невский проспект" },
                    { 29, "Сенная площадь" },
                    { 30, "Технологический институт(2)" },
                    { 31, "Фрунзенская" },
                    { 32, "Московские ворота" },
                    { 33, "Электросила" },
                    { 34, "Парк Победы" },
                    { 35, "Московская" },
                    { 36, "Звёздная" },
                    { 37, "Купчино" },
                    { 38, "Беговая" },
                    { 39, "Зенит" },
                    { 40, "Приморская" },
                    { 41, "Василеостровская" },
                    { 42, "Гостиный двор" }
                });

            migrationBuilder.InsertData(
                table: "SubwayStations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 43, "Маяковская" },
                    { 44, "Площадь Александра Невского(1)" },
                    { 45, "Елизаровская" },
                    { 46, "Ломоносовская" },
                    { 47, "Пролетарская" },
                    { 48, "Обухово" },
                    { 49, "Рыбацкое" },
                    { 50, "Спасская" },
                    { 51, "Достоевская" },
                    { 52, "Лиговский проспект" },
                    { 53, "Площадь Александра Невского(2)" },
                    { 54, "Новочеркасская" },
                    { 55, "Ладожская" },
                    { 56, "Проспект Большевиков" },
                    { 57, "Улица Дыбенко" },
                    { 58, "Комендантский проспект" },
                    { 59, "Старая Деревня" },
                    { 60, "Крестовский остров" },
                    { 61, "Чкаловская" },
                    { 62, "Спортивная" },
                    { 63, "Адмиралтейская" },
                    { 64, "Садовая" },
                    { 65, "Звенигородская" },
                    { 66, "Обводный канал" },
                    { 67, "Волковская" },
                    { 68, "Бухарестская" },
                    { 69, "Международная" },
                    { 70, "Проспект Славы" },
                    { 71, "Дунайская" },
                    { 72, "Шушуары" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogOrder_OrdersId",
                table: "DogOrder",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiсe_Services_ServiceId",
                table: "OrderServiсe",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServiсe_Services_ServiceId",
                table: "OrderServiсe");

            migrationBuilder.DropTable(
                name: "DogOrder");

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "SubwayStations",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "OrderServiсe",
                newName: "ServiceICollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderServiсe_ServiceId",
                table: "OrderServiсe",
                newName: "IX_OrderServiсe_ServiceICollectionId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "House",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Apartament",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OrderId",
                table: "Dogs",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Orders_OrderId",
                table: "Dogs",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServiсe_Services_ServiceICollectionId",
                table: "OrderServiсe",
                column: "ServiceICollectionId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
