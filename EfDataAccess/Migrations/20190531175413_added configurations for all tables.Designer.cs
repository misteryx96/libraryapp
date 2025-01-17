﻿// <auto-generated />
using System;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfDataAccess.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190531175413_added configurations for all tables")]
    partial class addedconfigurationsforalltables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableCount");

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Title");

                    b.Property<int>("WriterId");

                    b.HasKey("Id");

                    b.HasIndex("WriterId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.BookGenre", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("GenreId");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("Domain.BookReservation", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("ReservationId");

                    b.HasKey("BookId", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("BookReservation");
                });

            modelBuilder.Entity("Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DateExpiry");

                    b.Property<DateTime>("DateTaken");

                    b.Property<DateTime>("DateToReturn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.HasOne("Domain.Writer", "Writer")
                        .WithMany("Books")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.BookGenre", b =>
                {
                    b.HasOne("Domain.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.BookReservation", b =>
                {
                    b.HasOne("Domain.Book", "Book")
                        .WithMany("BookReservations")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Reservation", "Reservation")
                        .WithMany("BookReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Reservation", b =>
                {
                    b.HasOne("Domain.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.HasOne("Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
