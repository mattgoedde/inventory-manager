﻿// <auto-generated />
using System;
using Inventory.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory.DataAccess.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20230421213809_TenantUpdates")]
    partial class TenantUpdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Inventory.Domain.Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("ItemEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

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
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("LocationTypes");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TagEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TenantEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ItemEntityTagEntity", b =>
                {
                    b.Property<Guid>("ItemsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("ItemEntityTagEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TrackedItemEntity", b =>
                {
                    b.HasBaseType("Inventory.Domain.Entities.ItemEntity");

                    b.Property<string>("LotNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("LocationId");

                    b.HasDiscriminator().HasValue("TrackedItemEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.UntrackedItemEntity", b =>
                {
                    b.HasBaseType("Inventory.Domain.Entities.ItemEntity");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("LocationId");

                    b.HasDiscriminator().HasValue("UntrackedItemEntity");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.ItemEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("Items")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.LocationEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.LocationTypeEntity", "LocationType")
                        .WithMany("Locations")
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Inventory.Domain.Entities.LocationEntity", "ParentLocation")
                        .WithMany("ChildLocations")
                        .HasForeignKey("ParentLocationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("Locations")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
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
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.TagEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.TenantEntity", "Tenant")
                        .WithMany("Tags")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
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

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Inventory.Domain.Entities.UntrackedItemEntity", b =>
                {
                    b.HasOne("Inventory.Domain.Entities.LocationEntity", "Location")
                        .WithMany("UntrackedItems")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
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
                    b.Navigation("Items");

                    b.Navigation("LocationTypes");

                    b.Navigation("Locations");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
