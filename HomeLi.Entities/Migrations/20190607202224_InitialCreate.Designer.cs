﻿// <auto-generated />
using System;
using HomeLi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeLi.Entities.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190607202224_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeLi.Entities.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AuthorId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("HomeLi.Entities.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BookId");

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("ISBN")
                        .HasMaxLength(13);

                    b.Property<Guid?>("SerieId");

                    b.Property<Guid?>("SeriesId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("HomeLi.Entities.Models.Series", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SerieId");

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("HomeLi.Entities.Models.Book", b =>
                {
                    b.HasOne("HomeLi.Entities.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeLi.Entities.Models.Series", "Series")
                        .WithMany("Books")
                        .HasForeignKey("SeriesId");
                });

            modelBuilder.Entity("HomeLi.Entities.Models.Series", b =>
                {
                    b.HasOne("HomeLi.Entities.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
