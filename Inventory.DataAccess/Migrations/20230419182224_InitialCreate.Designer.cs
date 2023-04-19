﻿// <auto-generated />
using System;
using Inventory.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.DataAccess.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20230419182224_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Inventory.Domain.Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentLocationId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationTypeId");

                    b.HasIndex("ParentLocationId");

                    b.HasIndex("TenantId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("LocationTypes");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TenantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ItemEntityTagEntity", b =>
                {
                    b.Property<Guid>("ItemsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("TEXT");

                    b.HasKey("ItemsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ItemEntityTagEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TrackedItemEntity", b =>
                {
                    b.HasBaseType("Inventory.Domain.Entities.ItemEntity");

                    b.Property<string>("LotNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("LocationId");

                    b.HasIndex("TenantId");

                    b.HasDiscriminator().HasValue("TrackedItemEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.UntrackedItemEntity", b =>
                {
                    b.HasBaseType("Inventory.Domain.Entities.ItemEntity");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasIndex("LocationId");

                    b.HasIndex("TenantId");

                    b.HasDiscriminator().HasValue("UntrackedItemEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.LocationTypeEntity", "LocationType")
                        .WithMany("Locations")
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Entities.LocationEntity", "ParentLocation")
                        .WithMany("ChildLocations")
                        .HasForeignKey("ParentLocationId");

                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationType");

                    b.Navigation("ParentLocation");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationTypeEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("LocationTypes")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TagEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("Tags")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("ItemEntityTagEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.ItemEntity", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Entities.TagEntity", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TrackedItemEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.LocationEntity", "Location")
                        .WithMany("TrackedItems")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("TrackedItems")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.UntrackedItemEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.LocationEntity", "Location")
                        .WithMany("UntrackedItems")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("UntrackedItems")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationEntity", b =>
                {
                    b.Navigation("ChildLocations");

                    b.Navigation("TrackedItems");

                    b.Navigation("UntrackedItems");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationTypeEntity", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TenantEntity", b =>
                {
                    b.Navigation("LocationTypes");

                    b.Navigation("Locations");

                    b.Navigation("Tags");

                    b.Navigation("TrackedItems");

                    b.Navigation("UntrackedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
