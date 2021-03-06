﻿// <auto-generated />
using System;
using KeukenhofWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeukenhofWebsite.Migrations
{
    [DbContext(typeof(KeukenhofWebsiteContext))]
    partial class KeukenhofWebsiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KeukenhofWebsite.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PagAction");

                    b.Property<string>("pagTitle");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Username");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PaginaId");

                    b.Property<string>("Tekst");

                    b.Property<string>("Titel")
                        .IsRequired();

                    b.HasKey("ContentId");

                    b.HasIndex("PaginaId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PaginaId");

                    b.Property<string>("Path");

                    b.HasKey("ImageId");

                    b.HasIndex("PaginaId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Pagina", b =>
                {
                    b.Property<int>("PaginaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titel")
                        .IsRequired();

                    b.HasKey("PaginaId");

                    b.ToTable("Pagina");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Park", b =>
                {
                    b.Property<string>("Naam")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Openingsdag");

                    b.Property<DateTime>("OpeningstijdDinsdag");

                    b.Property<DateTime>("OpeningstijdDonderdag");

                    b.Property<DateTime>("OpeningstijdMaandag");

                    b.Property<DateTime>("OpeningstijdVrijdag");

                    b.Property<DateTime>("OpeningstijdWoensdag");

                    b.Property<DateTime>("OpeningstijdZaterdag");

                    b.Property<DateTime>("OpeningstijdZondag");

                    b.Property<DateTime>("Sluitingsdag");

                    b.Property<DateTime>("SluitingstijdDinsdag");

                    b.Property<DateTime>("SluitingstijdDonderdag");

                    b.Property<DateTime>("SluitingstijdMaandag");

                    b.Property<DateTime>("SluitingstijdVrijdag");

                    b.Property<DateTime>("SluitingstijdWoensdag");

                    b.Property<DateTime>("SluitingstijdZaterdag");

                    b.Property<DateTime>("SluitingstijdZondag");

                    b.HasKey("Naam");

                    b.ToTable("Park");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.QenA", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer");

                    b.Property<string>("Question");

                    b.HasKey("AnswerId");

                    b.ToTable("QenA");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Zoekterm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ZoektermString");

                    b.HasKey("Id");

                    b.ToTable("Zoekterm");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.ZoektermAction", b =>
                {
                    b.Property<int>("ZoektermId");

                    b.Property<int>("ActionId");

                    b.HasKey("ZoektermId", "ActionId");

                    b.HasIndex("ActionId");

                    b.ToTable("ZoektermAction");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Content", b =>
                {
                    b.HasOne("KeukenhofWebsite.Models.Pagina")
                        .WithMany("Contents")
                        .HasForeignKey("PaginaId");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Image", b =>
                {
                    b.HasOne("KeukenhofWebsite.Models.Pagina")
                        .WithMany("Images")
                        .HasForeignKey("PaginaId");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.ZoektermAction", b =>
                {
                    b.HasOne("KeukenhofWebsite.Models.Action", "Action")
                        .WithMany("ZoektermActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KeukenhofWebsite.Models.Zoekterm", "Zoekterm")
                        .WithMany("ZoektermActions")
                        .HasForeignKey("ZoektermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
