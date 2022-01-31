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
    [Migration("20220131201534_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AddressSubwayStation", b =>
                {
                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("SubwayStationsId")
                        .HasColumnType("int");

                    b.HasKey("AdressId", "SubwayStationsId");

                    b.HasIndex("SubwayStationsId");

                    b.ToTable("AddressSubwayStation");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apartament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("DogSitter.DAL.Entity.Admin", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("SitterId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SitterId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactTypes");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");
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

                    b.Property<int?>("CustomerId")
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

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

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

                    b.Property<int?>("CustomerId")
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

                    b.Property<int?>("SitterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId")
                        .IsUnique()
                        .HasFilter("[CommentId] IS NOT NULL");

                    b.HasIndex("CustomerId");

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

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SitterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SitterId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassportId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PassportId")
                        .IsUnique();

                    b.ToTable("Sitters");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.SubwayStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubwayStations");
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

                    b.Property<int>("Weekdays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SitterId");

                    b.ToTable("WorkTimes");
                });

            modelBuilder.Entity("AddressSubwayStation", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Address", null)
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.SubwayStation", null)
                        .WithMany()
                        .HasForeignKey("SubwayStationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Contact", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Admin", "Admin")
                        .WithMany("Contacts")
                        .HasForeignKey("AdminId");

                    b.HasOne("DogSitter.DAL.Entity.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId");

                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("Contacts")
                        .HasForeignKey("SitterId");

                    b.Navigation("Admin");

                    b.Navigation("ContactType");

                    b.Navigation("Customer");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Dog", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany("Dogs")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DogSitter.DAL.Entity.Order", null)
                        .WithMany("Dogs")
                        .HasForeignKey("OrderId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Order", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Comment", "Comment")
                        .WithOne("Order")
                        .HasForeignKey("DogSitter.DAL.Entity.Order", "CommentId");

                    b.HasOne("DogSitter.DAL.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("Orders")
                        .HasForeignKey("SitterId");

                    b.Navigation("Comment");

                    b.Navigation("Customer");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Serviсe", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Order", "Order")
                        .WithMany("ServiceICollection")
                        .HasForeignKey("OrderId");

                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("ServiceICollection")
                        .HasForeignKey("SitterId");

                    b.Navigation("Order");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogSitter.DAL.Entity.Customer", null)
                        .WithMany("Sitter")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DogSitter.DAL.Entity.Passport", "Passport")
                        .WithOne("Sitter")
                        .HasForeignKey("DogSitter.DAL.Entity.Sitter", "PassportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.WorkTime", b =>
                {
                    b.HasOne("DogSitter.DAL.Entity.Sitter", "Sitter")
                        .WithMany("WorkTime")
                        .HasForeignKey("SitterId");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Admin", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Comment", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Customer", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Dogs");

                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Order", b =>
                {
                    b.Navigation("Dogs");

                    b.Navigation("ServiceICollection");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Passport", b =>
                {
                    b.Navigation("Sitter");
                });

            modelBuilder.Entity("DogSitter.DAL.Entity.Sitter", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Orders");

                    b.Navigation("ServiceICollection");

                    b.Navigation("WorkTime");
                });
#pragma warning restore 612, 618
        }
    }
}
