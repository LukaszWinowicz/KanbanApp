﻿// <auto-generated />
using System;
using KanbanApp.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KanbanApp.API.Migrations
{
    [DbContext(typeof(KanbanDbContext))]
    partial class KanbanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KanbanApp.API.Entities.Rack", b =>
                {
                    b.Property<string>("RackName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RackName");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Item", b =>
                {
                    b.Property<string>("ItemNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Factor10Pcs")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemNumber");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<int>("BoxSize")
                        .HasColumnType("int");

                    b.Property<int>("BoxType")
                        .HasColumnType("int");

                    b.Property<string>("ItemNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ScaleId")
                        .HasColumnType("int");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ShelfSpace")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("LocationId");

                    b.HasIndex("ItemNumber");

                    b.HasIndex("LocationName")
                        .IsUnique();

                    b.HasIndex("RackName");

                    b.HasIndex("ScaleId")
                        .IsUnique();

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Reading", b =>
                {
                    b.Property<int>("ReadingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReadingId"));

                    b.Property<DateTime>("ReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ReadingWeight")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ScaleId")
                        .HasColumnType("int");

                    b.HasKey("ReadingId");

                    b.HasIndex("ScaleId");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Scale", b =>
                {
                    b.Property<int>("ScaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScaleId"));

                    b.Property<decimal>("CalibrationFactor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("InitialWeight")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ScaleId");

                    b.ToTable("Scales");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Location", b =>
                {
                    b.HasOne("KanbanBlazorApp.Entities.Item", "Item")
                        .WithMany("Locations")
                        .HasForeignKey("ItemNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KanbanApp.API.Entities.Rack", "Rack")
                        .WithMany("Locations")
                        .HasForeignKey("RackName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KanbanBlazorApp.Entities.Scale", "Scale")
                        .WithOne("Location")
                        .HasForeignKey("KanbanBlazorApp.Entities.Location", "ScaleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Rack");

                    b.Navigation("Scale");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Reading", b =>
                {
                    b.HasOne("KanbanBlazorApp.Entities.Scale", "Scale")
                        .WithMany("Readings")
                        .HasForeignKey("ScaleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Scale");
                });

            modelBuilder.Entity("KanbanApp.API.Entities.Rack", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Item", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("KanbanBlazorApp.Entities.Scale", b =>
                {
                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}
