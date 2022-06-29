﻿// <auto-generated />
using System;
using BankReport.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankReport.Context.Migrations
{
    [DbContext(typeof(ReportBankDbContext))]
    [Migration("20220629144009_Added_Transaction")]
    partial class Added_Transaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("BankReport.DatabaseModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccountType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<string>("Iban")
                        .HasColumnType("TEXT");

                    b.Property<string>("QwnerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankReport.DatabaseModels.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AccountIdId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("CategoryTransaction")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountIdId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankReport.DatabaseModels.Transaction", b =>
                {
                    b.HasOne("BankReport.DatabaseModels.Account", "AccountId")
                        .WithMany("TransactionId")
                        .HasForeignKey("AccountIdId");

                    b.Navigation("AccountId");
                });

            modelBuilder.Entity("BankReport.DatabaseModels.Account", b =>
                {
                    b.Navigation("TransactionId");
                });
#pragma warning restore 612, 618
        }
    }
}
