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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
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
                name: "SubwayStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubwayStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weekdays = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.Id);
                });

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
                name: "Sitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PassportId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sitters_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sitters_Passports_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passports",
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SitterId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    DogsId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Orders_Dogs_DogsId",
                        column: x => x.DogsId,
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
                name: "IX_AddressCustomer_CustomersId",
                table: "AddressCustomer",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressSubwayStation_SubwayStationsId",
                table: "AddressSubwayStation",
                column: "SubwayStationsId");

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
                name: "IX_Orders_DogsId",
                table: "Orders",
                column: "DogsId");

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
                name: "IX_Sitters_AddressId",
                table: "Sitters",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_PassportId",
                table: "Sitters",
                column: "PassportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SitterWorkTime_WorkTimeId",
                table: "SitterWorkTime",
                column: "WorkTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCustomer");

            migrationBuilder.DropTable(
                name: "AddressSubwayStation");

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
                name: "SubwayStations");

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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Passports");
        }
    }
}
