﻿// <auto-generated />
using System;
using GreenFairy.DomainLayer.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenFairy.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230124154953_24_01_2023")]
    partial class _24012023
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AdminEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ClientEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryKind")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderHistoryEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentKind")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderHistoryEntityId");

                    b.ToTable("OrderEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("OrderHistoryEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PlantEntities");
                });

            modelBuilder.Entity("OrderEntityPlantEntity", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlantsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdersId", "PlantsId");

                    b.HasIndex("PlantsId");

                    b.ToTable("OrderEntityPlantEntity");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", b =>
                {
                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.OrderHistoryEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("OrderHistoryEntityId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderHistoryEntity", b =>
                {
                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("OrderEntityPlantEntity", b =>
                {
                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", null)
                        .WithMany()
                        .HasForeignKey("PlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderHistoryEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
