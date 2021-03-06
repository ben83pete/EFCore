﻿// <auto-generated />
using System;
using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreTutorial.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190220151438_added FK")]
    partial class addedFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTutorial.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdateed");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("EFCoreTutorial.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<double>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("EFCoreTutorial.Models.Order", b =>
                {
                    b.HasOne("EFCoreTutorial.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
