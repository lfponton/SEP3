﻿// <auto-generated />
using System;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataServer.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20211213134324_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataServer.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataServer.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("DeliveryAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressNumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Door")
                        .HasColumnType("text");

                    b.Property<string>("PostNumber")
                        .HasColumnType("text");

                    b.Property<string>("StreetName")
                        .HasColumnType("text");

                    b.HasKey("DeliveryAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("DataServer.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataServer.Models.Menu", b =>
                {
                    b.Property<long>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("DataServer.Models.MenuItem", b =>
                {
                    b.Property<long>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("DataServer.Models.MenuItemsSelection", b =>
                {
                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("MenuItemId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MenuId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuItemsSelections");
                });

            modelBuilder.Entity("DataServer.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<int?>("DeliveryAddressId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDelivery")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryAddressId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataServer.Models.OrderItem", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("DataServer.Models.Restaurant", b =>
                {
                    b.Property<long>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("DataServer.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("DataServer.Models.TableBooking", b =>
                {
                    b.Property<long>("TableBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BookingDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("People")
                        .HasColumnType("integer");

                    b.Property<int?>("TableId")
                        .HasColumnType("integer");

                    b.HasKey("TableBookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("TableBookings");
                });

            modelBuilder.Entity("DataServer.Models.MenuItemsSelection", b =>
                {
                    b.HasOne("DataServer.Models.Menu", "Menu")
                        .WithMany("MenuItemsSelections")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataServer.Models.MenuItem", "MenuItem")
                        .WithMany("MenuItemsSelections")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("DataServer.Models.Order", b =>
                {
                    b.HasOne("DataServer.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataServer.Models.DeliveryAddress", "DeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DeliveryAddressId");

                    b.Navigation("Customer");

                    b.Navigation("DeliveryAddress");
                });

            modelBuilder.Entity("DataServer.Models.OrderItem", b =>
                {
                    b.HasOne("DataServer.Models.Menu", "Menu")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataServer.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataServer.Models.Table", b =>
                {
                    b.HasOne("DataServer.Models.Restaurant", null)
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId");
                });

            modelBuilder.Entity("DataServer.Models.TableBooking", b =>
                {
                    b.HasOne("DataServer.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataServer.Models.Table", "Table")
                        .WithMany("TableBookings")
                        .HasForeignKey("TableId");

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("DataServer.Models.Menu", b =>
                {
                    b.Navigation("MenuItemsSelections");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataServer.Models.MenuItem", b =>
                {
                    b.Navigation("MenuItemsSelections");
                });

            modelBuilder.Entity("DataServer.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("DataServer.Models.Restaurant", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("DataServer.Models.Table", b =>
                {
                    b.Navigation("TableBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
