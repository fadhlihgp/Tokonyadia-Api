﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tokonyadia_Api.Repositories;

#nullable disable

namespace TokonyadiaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230121231013_date")]
    partial class date
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tokonyadia_Api.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("address");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("customer_name");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVarchar(14)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("m_customer");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("product_name");

                    b.HasKey("Id");

                    b.ToTable("m_product");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.ProductPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<long>("Price")
                        .HasColumnType("bigint")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("store_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("m_product_price");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("TransDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("trans_date");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("t_purchase");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.PurchaseDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("ProductPriceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_price_id");

                    b.Property<Guid>("PurchaseId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchase_id");

                    b.Property<int>("Qty")
                        .HasColumnType("int")
                        .HasColumnName("qty");

                    b.HasKey("Id");

                    b.HasIndex("ProductPriceId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("t_purchase_detail");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("address");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVarchar(14)")
                        .HasColumnName("phone_number");

                    b.Property<string>("SiupNumber")
                        .IsRequired()
                        .HasColumnType("NVarchar(9)")
                        .HasColumnName("siup_number");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("store_name");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("SiupNumber")
                        .IsUnique();

                    b.ToTable("m_store");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.ProductPrice", b =>
                {
                    b.HasOne("Tokonyadia_Api.Entities.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tokonyadia_Api.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Purchase", b =>
                {
                    b.HasOne("Tokonyadia_Api.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("Tokonyadia_Api.Entities.ProductPrice", "ProductPrice")
                        .WithMany()
                        .HasForeignKey("ProductPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tokonyadia_Api.Entities.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductPrice");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Product", b =>
                {
                    b.Navigation("ProductPrices");
                });

            modelBuilder.Entity("Tokonyadia_Api.Entities.Purchase", b =>
                {
                    b.Navigation("PurchaseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
