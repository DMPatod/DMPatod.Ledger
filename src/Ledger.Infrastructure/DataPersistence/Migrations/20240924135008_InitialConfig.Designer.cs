﻿// <auto-generated />
using System;
using Ledger.Infrastructure.DataPersistence.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ledger.Infrastructure.DataPersistence.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20240924135008_InitialConfig")]
    partial class InitialConfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ledger.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MesureUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Ledger.Domain.Providers.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers", (string)null);
                });

            modelBuilder.Entity("Ledger.Domain.Tickets.Entity.Order", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("ProductId", "TicketId", "Value", "Amount");

                    b.HasIndex("TicketId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Ledger.Domain.Tickets.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<int>("Installments")
                        .HasColumnType("int");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Ledger.Domain.Tickets.Entity.Order", b =>
                {
                    b.HasOne("Ledger.Domain.Products.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ledger.Domain.Tickets.Ticket", "Ticket")
                        .WithMany("Orders")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Ledger.Domain.Tickets.Ticket", b =>
                {
                    b.HasOne("Ledger.Domain.Providers.Provider", "Provider")
                        .WithMany("Tickets")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Ledger.Domain.Products.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Ledger.Domain.Providers.Provider", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Ledger.Domain.Tickets.Ticket", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}