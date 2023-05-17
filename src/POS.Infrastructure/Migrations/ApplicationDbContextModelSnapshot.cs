﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using POS.Infrastructure.DatabaseContext;

#nullable disable

namespace POS.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("POS.Core.Domain.Entities.CustomerPurchasePerProduct", b =>
                {
                    b.Property<int>("CustomerPurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerPurchaseID"));

                    b.Property<decimal>("AmountPerProduct")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("ReceiptID")
                        .HasColumnType("integer");

                    b.HasKey("CustomerPurchaseID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ReceiptID");

                    b.ToTable("CustomerPurchasePerProducts");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InventoryID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Units")
                        .HasColumnType("integer");

                    b.Property<decimal>("WholesalePricePerInventory")
                        .HasColumnType("numeric");

                    b.Property<int>("productID")
                        .HasColumnType("integer");

                    b.HasKey("InventoryID");

                    b.HasIndex("productID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Receipt", b =>
                {
                    b.Property<int>("ReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReceiptID"));

                    b.Property<DateTime>("ReceiptDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReceiptID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.CustomerPurchasePerProduct", b =>
                {
                    b.HasOne("POS.Core.Domain.Entities.Product", "Product")
                        .WithMany("CustomerPurchasesPerProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Core.Domain.Entities.Receipt", "Receipt")
                        .WithMany("CustomerPurchasePerProducts")
                        .HasForeignKey("ReceiptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Receipt");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Inventory", b =>
                {
                    b.HasOne("POS.Core.Domain.Entities.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("CustomerPurchasesPerProducts");

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("POS.Core.Domain.Entities.Receipt", b =>
                {
                    b.Navigation("CustomerPurchasePerProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
