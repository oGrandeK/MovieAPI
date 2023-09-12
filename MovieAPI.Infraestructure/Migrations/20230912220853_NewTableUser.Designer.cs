﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPI.Infraestructure.Context;

#nullable disable

namespace MovieAPI.Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230912220853_NewTableUser")]
    partial class NewTableUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieAPI.Domain.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<byte?>("DurationInMinutes")
                        .HasColumnType("tinyint");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.Director", b =>
                {
                    b.OwnsOne("MovieAPI.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("DirectorId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("Name_FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("Name_LastName");

                            b1.HasKey("DirectorId");

                            b1.ToTable("Directors");

                            b1.WithOwner()
                                .HasForeignKey("DirectorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.Movie", b =>
                {
                    b.HasOne("MovieAPI.Domain.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MovieAPI.Domain.ValueObjects.Title", "Title", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("int");

                            b1.Property<string>("MovieTitle")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");
                        });

                    b.Navigation("Director");

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.User", b =>
                {
                    b.OwnsOne("MovieAPI.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("NVARCHAR(100)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("NVARCHAR(100)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("MovieAPI.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("MovieAPI.Domain.ValueObjects.Verification", "Verification", b2 =>
                                {
                                    b2.Property<int>("EmailUserId")
                                        .HasColumnType("int");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("EmailVerificationCode");

                                    b2.Property<DateTime?>("ExpiresAt")
                                        .HasColumnType("datetime2")
                                        .HasColumnName("EmailVerificationExpiresAt");

                                    b2.Property<DateTime?>("VerifiedAt")
                                        .HasColumnType("datetime2")
                                        .HasColumnName("EmailVerificationVerifiedAt");

                                    b2.HasKey("EmailUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("EmailUserId");
                                });

                            b1.Navigation("Verification");
                        });

                    b.OwnsOne("MovieAPI.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PasswordHash");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Name");

                    b.Navigation("Password");
                });

            modelBuilder.Entity("MovieAPI.Domain.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
