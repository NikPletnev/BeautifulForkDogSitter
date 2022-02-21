using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Apartament = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationHours = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubwayStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubwayStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubwayStations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PassportId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SubwayStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sitters_Passports_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sitters_SubwayStations_SubwayStationId",
                        column: x => x.SubwayStationId,
                        principalTable: "SubwayStations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sitters_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    SitterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Sitters_SitterId",
                        column: x => x.SitterId,
                        principalTable: "Sitters",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Mark = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SitterId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Sitters_SitterId",
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
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServiсe", x => new { x.OrdersId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_OrderServiсe_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderServiсe_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubwayStations",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Девяткино" },
                    { 2, null, "Гражданский проспект" },
                    { 3, null, "Академическая" },
                    { 4, null, "Политехническая" },
                    { 5, null, "Площадь Мужества" },
                    { 6, null, "Лесная" },
                    { 7, null, "Выборгская" },
                    { 8, null, "Площадь Ленина" },
                    { 9, null, "Чернышевская" },
                    { 10, null, "Площадь Восстания" },
                    { 11, null, "Владимирская" },
                    { 12, null, "Пушкинская" },
                    { 13, null, "Технологический институт(1)" },
                    { 14, null, "Балтийская" },
                    { 15, null, "Нарвская" },
                    { 16, null, "Кировский завод" },
                    { 17, null, "Автово" },
                    { 18, null, "Ленинский проспект" },
                    { 19, null, "Проспект Ветеранов" },
                    { 20, null, "Парнас" },
                    { 21, null, "Проспект Просвещения" },
                    { 22, null, "Озерки" },
                    { 23, null, "Удельная" },
                    { 24, null, "Пионерская" },
                    { 25, null, "Чёрная речка" },
                    { 26, null, "Петроградская" },
                    { 27, null, "Горьковская" },
                    { 28, null, "Невский проспект" },
                    { 29, null, "Сенная площадь" },
                    { 30, null, "Технологический институт(2)" },
                    { 31, null, "Фрунзенская" },
                    { 32, null, "Московские ворота" },
                    { 33, null, "Электросила" },
                    { 34, null, "Парк Победы" },
                    { 35, null, "Московская" },
                    { 36, null, "Звёздная" },
                    { 37, null, "Купчино" },
                    { 38, null, "Беговая" },
                    { 39, null, "Зенит" },
                    { 40, null, "Приморская" },
                    { 41, null, "Василеостровская" },
                    { 42, null, "Гостиный двор" }
                });

            migrationBuilder.InsertData(
                table: "SubwayStations",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[,]
                {
                    { 43, null, "Маяковская" },
                    { 44, null, "Площадь Александра Невского(1)" },
                    { 45, null, "Елизаровская" },
                    { 46, null, "Ломоносовская" },
                    { 47, null, "Пролетарская" },
                    { 48, null, "Обухово" },
                    { 49, null, "Рыбацкое" },
                    { 50, null, "Спасская" },
                    { 51, null, "Достоевская" },
                    { 52, null, "Лиговский проспект" },
                    { 53, null, "Площадь Александра Невского(2)" },
                    { 54, null, "Новочеркасская" },
                    { 55, null, "Ладожская" },
                    { 56, null, "Проспект Большевиков" },
                    { 57, null, "Улица Дыбенко" },
                    { 58, null, "Комендантский проспект" },
                    { 59, null, "Старая Деревня" },
                    { 60, null, "Крестовский остров" },
                    { 61, null, "Чкаловская" },
                    { 62, null, "Спортивная" },
                    { 63, null, "Адмиралтейская" },
                    { 64, null, "Садовая" },
                    { 65, null, "Звенигородская" },
                    { 66, null, "Обводный канал" },
                    { 67, null, "Волковская" },
                    { 68, null, "Бухарестская" },
                    { 69, null, "Международная" },
                    { 70, null, "Проспект Славы" },
                    { 71, null, "Дунайская" },
                    { 72, null, "Шушуары" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AdminId",
                table: "Contacts",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SitterId",
                table: "Contacts",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSitter_SitterId",
                table: "CustomerSitter",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_CustomerId",
                table: "Dogs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CommentId",
                table: "Orders",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DogId",
                table: "Orders",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SitterId",
                table: "Orders",
                column: "SitterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiсe_ServiceId",
                table: "OrderServiсe",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiсeSitter_SittersId",
                table: "ServiсeSitter",
                column: "SittersId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_PassportId",
                table: "Sitters",
                column: "PassportId",
                unique: true,
                filter: "[PassportId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_SubwayStationId",
                table: "Sitters",
                column: "SubwayStationId");

            migrationBuilder.CreateIndex(
                name: "IX_SitterWorkTime_WorkTimeId",
                table: "SitterWorkTime",
                column: "WorkTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubwayStations_AddressId",
                table: "SubwayStations",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CustomerSitter");

            migrationBuilder.DropTable(
                name: "OrderServiсe");

            migrationBuilder.DropTable(
                name: "ServiсeSitter");

            migrationBuilder.DropTable(
                name: "SitterWorkTime");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "SubwayStations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
