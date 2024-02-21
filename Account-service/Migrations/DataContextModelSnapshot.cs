﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using account_service.Data;

#nullable disable

namespace account_service.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("account_service.Models.Account", b =>
                {
                    b.Property<string>("accountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("accountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.HasKey("accountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            accountId = "A1",
                            accountType = "CURRENT_ACCOUNT",
                            balance = 12.0,
                            createdAt = new DateTime(2024, 2, 21, 17, 10, 44, 556, DateTimeKind.Utc).AddTicks(4165),
                            currency = "DHs",
                            customerId = 1L
                        },
                        new
                        {
                            accountId = "A2",
                            accountType = "SAVING_ACCOUNT",
                            balance = 14.0,
                            createdAt = new DateTime(2024, 2, 21, 17, 10, 44, 556, DateTimeKind.Utc).AddTicks(4247),
                            currency = "Dollar",
                            customerId = 2L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}