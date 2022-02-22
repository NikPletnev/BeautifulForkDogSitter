﻿// <auto-generated />
using System;
using DogSitter.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogSitter.DAL.Migrations
{
    [DbContext(typeof(DogSitterContext))]
    [Migration("20220221231219_EditAdress")]
    partial class EditAdress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerSitter", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("SitterId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "SitterId");

                    b.HasIndex("SitterId");

                    b.ToTable("CustomerSitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Apartament")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("House")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("DogId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("Mark")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SitterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("CommentId")
                        .IsUnique()
                        .HasFilter("[CommentId] IS NOT NULL");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DogId");

                    b.HasIndex("SitterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Passport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Serviсe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DurationHours")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SitterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SitterId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.SubwayStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("SubwayStations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Девяткино"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Гражданский проспект"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Академическая"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Политехническая"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Площадь Мужества"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Лесная"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Выборгская"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Площадь Ленина"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Чернышевская"
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Площадь Восстания"
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "Владимирская"
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "Пушкинская"
                        },
                        new
                        {
                            Id = 13,
                            IsDeleted = false,
                            Name = "Технологический институт(1)"
                        },
                        new
                        {
                            Id = 14,
                            IsDeleted = false,
                            Name = "Балтийская"
                        },
                        new
                        {
                            Id = 15,
                            IsDeleted = false,
                            Name = "Нарвская"
                        },
                        new
                        {
                            Id = 16,
                            IsDeleted = false,
                            Name = "Кировский завод"
                        },
                        new
                        {
                            Id = 17,
                            IsDeleted = false,
                            Name = "Автово"
                        },
                        new
                        {
                            Id = 18,
                            IsDeleted = false,
                            Name = "Ленинский проспект"
                        },
                        new
                        {
                            Id = 19,
                            IsDeleted = false,
                            Name = "Проспект Ветеранов"
                        },
                        new
                        {
                            Id = 20,
                            IsDeleted = false,
                            Name = "Парнас"
                        },
                        new
                        {
                            Id = 21,
                            IsDeleted = false,
                            Name = "Проспект Просвещения"
                        },
                        new
                        {
                            Id = 22,
                            IsDeleted = false,
                            Name = "Озерки"
                        },
                        new
                        {
                            Id = 23,
                            IsDeleted = false,
                            Name = "Удельная"
                        },
                        new
                        {
                            Id = 24,
                            IsDeleted = false,
                            Name = "Пионерская"
                        },
                        new
                        {
                            Id = 25,
                            IsDeleted = false,
                            Name = "Чёрная речка"
                        },
                        new
                        {
                            Id = 26,
                            IsDeleted = false,
                            Name = "Петроградская"
                        },
                        new
                        {
                            Id = 27,
                            IsDeleted = false,
                            Name = "Горьковская"
                        },
                        new
                        {
                            Id = 28,
                            IsDeleted = false,
                            Name = "Невский проспект"
                        },
                        new
                        {
                            Id = 29,
                            IsDeleted = false,
                            Name = "Сенная площадь"
                        },
                        new
                        {
                            Id = 30,
                            IsDeleted = false,
                            Name = "Технологический институт(2)"
                        },
                        new
                        {
                            Id = 31,
                            IsDeleted = false,
                            Name = "Фрунзенская"
                        },
                        new
                        {
                            Id = 32,
                            IsDeleted = false,
                            Name = "Московские ворота"
                        },
                        new
                        {
                            Id = 33,
                            IsDeleted = false,
                            Name = "Электросила"
                        },
                        new
                        {
                            Id = 34,
                            IsDeleted = false,
                            Name = "Парк Победы"
                        },
                        new
                        {
                            Id = 35,
                            IsDeleted = false,
                            Name = "Московская"
                        },
                        new
                        {
                            Id = 36,
                            IsDeleted = false,
                            Name = "Звёздная"
                        },
                        new
                        {
                            Id = 37,
                            IsDeleted = false,
                            Name = "Купчино"
                        },
                        new
                        {
                            Id = 38,
                            IsDeleted = false,
                            Name = "Беговая"
                        },
                        new
                        {
                            Id = 39,
                            IsDeleted = false,
                            Name = "Зенит"
                        },
                        new
                        {
                            Id = 40,
                            IsDeleted = false,
                            Name = "Приморская"
                        },
                        new
                        {
                            Id = 41,
                            IsDeleted = false,
                            Name = "Василеостровская"
                        },
                        new
                        {
                            Id = 42,
                            IsDeleted = false,
                            Name = "Гостиный двор"
                        },
                        new
                        {
                            Id = 43,
                            IsDeleted = false,
                            Name = "Маяковская"
                        },
                        new
                        {
                            Id = 44,
                            IsDeleted = false,
                            Name = "Площадь Александра Невского(1)"
                        },
                        new
                        {
                            Id = 45,
                            IsDeleted = false,
                            Name = "Елизаровская"
                        },
                        new
                        {
                            Id = 46,
                            IsDeleted = false,
                            Name = "Ломоносовская"
                        },
                        new
                        {
                            Id = 47,
                            IsDeleted = false,
                            Name = "Пролетарская"
                        },
                        new
                        {
                            Id = 48,
                            IsDeleted = false,
                            Name = "Обухово"
                        },
                        new
                        {
                            Id = 49,
                            IsDeleted = false,
                            Name = "Рыбацкое"
                        },
                        new
                        {
                            Id = 50,
                            IsDeleted = false,
                            Name = "Спасская"
                        },
                        new
                        {
                            Id = 51,
                            IsDeleted = false,
                            Name = "Достоевская"
                        },
                        new
                        {
                            Id = 52,
                            IsDeleted = false,
                            Name = "Лиговский проспект"
                        },
                        new
                        {
                            Id = 53,
                            IsDeleted = false,
                            Name = "Площадь Александра Невского(2)"
                        },
                        new
                        {
                            Id = 54,
                            IsDeleted = false,
                            Name = "Новочеркасская"
                        },
                        new
                        {
                            Id = 55,
                            IsDeleted = false,
                            Name = "Ладожская"
                        },
                        new
                        {
                            Id = 56,
                            IsDeleted = false,
                            Name = "Проспект Большевиков"
                        },
                        new
                        {
                            Id = 57,
                            IsDeleted = false,
                            Name = "Улица Дыбенко"
                        },
                        new
                        {
                            Id = 58,
                            IsDeleted = false,
                            Name = "Комендантский проспект"
                        },
                        new
                        {
                            Id = 59,
                            IsDeleted = false,
                            Name = "Старая Деревня"
                        },
                        new
                        {
                            Id = 60,
                            IsDeleted = false,
                            Name = "Крестовский остров"
                        },
                        new
                        {
                            Id = 61,
                            IsDeleted = false,
                            Name = "Чкаловская"
                        },
                        new
                        {
                            Id = 62,
                            IsDeleted = false,
                            Name = "Спортивная"
                        },
                        new
                        {
                            Id = 63,
                            IsDeleted = false,
                            Name = "Адмиралтейская"
                        },
                        new
                        {
                            Id = 64,
                            IsDeleted = false,
                            Name = "Садовая"
                        },
                        new
                        {
                            Id = 65,
                            IsDeleted = false,
                            Name = "Звенигородская"
                        },
                        new
                        {
                            Id = 66,
                            IsDeleted = false,
                            Name = "Обводный канал"
                        },
                        new
                        {
                            Id = 67,
                            IsDeleted = false,
                            Name = "Волковская"
                        },
                        new
                        {
                            Id = 68,
                            IsDeleted = false,
                            Name = "Бухарестская"
                        },
                        new
                        {
                            Id = 69,
                            IsDeleted = false,
                            Name = "Международная"
                        },
                        new
                        {
                            Id = 70,
                            IsDeleted = false,
                            Name = "Проспект Славы"
                        },
                        new
                        {
                            Id = 71,
                            IsDeleted = false,
                            Name = "Дунайская"
                        },
                        new
                        {
                            Id = 72,
                            IsDeleted = false,
                            Name = "Шушуары"
                        });
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.WorkTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("SitterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SitterId");

                    b.ToTable("WorkTimes");
                });

            modelBuilder.Entity("OrderServiсe", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("OrdersId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderServiсe");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Admin", b =>
                {
                    b.HasBaseType("DogSitter.DAL.Entity.User");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.HasBaseType("DogSitter.DAL.Entity.User");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.HasBaseType("DogSitter.DAL.Entity.User");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassportId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int?>("SubwayStationId")
                        .HasColumnType("int");

                    b.Property<bool>("Verified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasIndex("PassportId")
                        .IsUnique()
                        .HasFilter("[PassportId] IS NOT NULL");

                    b.HasIndex("SubwayStationId");

                    b.ToTable("Sitters", (string)null);
                });

            modelBuilder.Entity("CustomerSitter", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.Sitter", null)
                        .WithMany()
                        .HasForeignKey("SitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Comment", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Contact", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Dog", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany("Dogs")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Order", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Comment", "Comment")
                        .WithOne("Order")
                        .HasForeignKey("DogSitter.DAL.Entity.Order", "CommentId");

                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.Dog", "Dog")
                        .WithMany("Orders")
                        .HasForeignKey("DogId");

                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("Orders")
                        .HasForeignKey("SitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Customer");

                    b.Navigation("Dog");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Serviсe", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("Services")
                        .HasForeignKey("SitterId");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.SubwayStation", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Address", null)
                        .WithMany("SubwayStations")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.WorkTime", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("WorkTime")
                        .HasForeignKey("SitterId");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("OrderServiсe", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.Serviсe", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Admin", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("DogSitter.DAL.Entity.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Address", "Address")
                        .WithOne("Customer")
                        .HasForeignKey("DogSitter.DAL.Entity.Customer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("DogSitter.DAL.Entity.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("DogSitter.DAL.Entity.Sitter", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.Passport", "Passport")
                        .WithOne("Sitter")
                        .HasForeignKey("DogSitter.DAL.Entity.Sitter", "PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.SubwayStation", "SubwayStation")
                        .WithMany("Sitters")
                        .HasForeignKey("SubwayStationId");

                    b.Navigation("Passport");

                    b.Navigation("SubwayStation");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Address", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("SubwayStations");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Comment", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Dog", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Passport", b =>
                {
                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.SubwayStation", b =>
                {
                    b.Navigation("Sitters");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.User", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Dogs");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Services");

                    b.Navigation("WorkTime");
                });
#pragma warning restore 612, 618
        }
    }
}
