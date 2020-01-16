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

                    b.Property<string>("Tekst");

                    b.HasKey("ContentId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("KeukenhofWebsite.Models.Park", b =>
                {
                    b.Property<string>("Naam")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Openingsdag");

                    b.Property<DateTime>("OpeningstijdenDinsdag");

                    b.Property<DateTime>("OpeningstijdenDonderdag");

                    b.Property<DateTime>("OpeningstijdenMaandag");

                    b.Property<DateTime>("OpeningstijdenVrijdag");

                    b.Property<DateTime>("OpeningstijdenWoensdag");

                    b.Property<DateTime>("OpeningstijdenZaterdag");

                    b.Property<DateTime>("OpeningstijdenZondag");

                    b.Property<DateTime>("Sluitingsdag");

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
#pragma warning restore 612, 618
        }
    }
}
