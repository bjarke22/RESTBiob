﻿// <auto-generated />
using System;
using Biob.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Biob.Data.Data.Migrations
{
    [DbContext(typeof(BiobDataContext))]
    [Migration("20181115124239_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Biob.Data.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actors");

                    b.Property<int>("AgeRestriction");

                    b.Property<string>("Description")
                        .HasMaxLength(5000);

                    b.Property<string>("Genre");

                    b.Property<int>("LengthInSeconds");

                    b.Property<string>("Poster");

                    b.Property<string>("Producer")
                        .HasMaxLength(255);

                    b.Property<DateTimeOffset>("Released");

                    b.Property<bool>("ThreeDee");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
