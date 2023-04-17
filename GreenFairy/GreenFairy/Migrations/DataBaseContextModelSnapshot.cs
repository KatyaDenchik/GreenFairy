﻿// <auto-generated />
using System;
using GreenFairy.DomainLayer.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenFairy.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
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

                    b.Property<string>("AddressOfDelivery")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryKind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentKind")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlantEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlantsCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PlantEntityId");

                    b.ToTable("OrderEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderedPlantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderingKind")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderEntityId");

                    b.HasIndex("PlantId");

                    b.ToTable("OrderedPlantEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PlantEntities");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", b =>
                {
                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("PlantEntityId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderedPlantEntity", b =>
                {
                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", null)
                        .WithMany("Plants")
                        .HasForeignKey("OrderEntityId");

                    b.HasOne("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.ClientEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.OrderEntity", b =>
                {
                    b.Navigation("Plants");
                });

            modelBuilder.Entity("GreenFairy.DomainLayer.DataBase.Entities.PlantEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
