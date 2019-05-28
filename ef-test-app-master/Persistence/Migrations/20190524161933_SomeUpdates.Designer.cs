﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20190524161933_SomeUpdates")]
    partial class SomeUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("LicenseId");

                    b.Property<string>("Location")
                        .HasMaxLength(20);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Persistence.Models.License", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CustomerId");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Persistence.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 5, 24, 19, 19, 33, 770, DateTimeKind.Local).AddTicks(1140));

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("LastChanged");

                    b.Property<string>("StatusString")
                        .HasColumnName("Status");

                    b.Property<double>("TotalPrice");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Persistence.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Persistence.Models.ProductOrder", b =>
                {
                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Amount");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("Persistence.Models.License", b =>
                {
                    b.HasOne("Persistence.Models.Customer", "Customer")
                        .WithOne("License")
                        .HasForeignKey("Persistence.Models.License", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Persistence.Models.Order", b =>
                {
                    b.HasOne("Persistence.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Persistence.Models.ProductOrder", b =>
                {
                    b.HasOne("Persistence.Models.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Persistence.Models.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
