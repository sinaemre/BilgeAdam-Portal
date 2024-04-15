﻿// <auto-generated />
using System;
using DataAccess.Context.IdentityContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Context.IdentityContext.Migrations
{
    [DbContext(typeof(AppIdentityDbContext))]
    partial class AppIdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Entities.UserEntities.Concrete.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LoginCount")
                        .HasColumnType("integer");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "371caecc-777f-4249-8c7d-bbb3f27a73b8",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "fcdc437f-f3c9-480a-a86c-b3d570105008",
                            CreatedDate = new DateTime(2024, 4, 2, 13, 57, 41, 420, DateTimeKind.Local).AddTicks(5876),
                            Email = "admin@bilgeadam.com",
                            EmailConfirmed = false,
                            FirstName = "Yönetici",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            LoginCount = 0,
                            NormalizedEmail = "ADMIN@BILGEADAM.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAED/UU0Hu7U/OyAOg3vyTPYu/MFTK6fhGdfVw+dD9BBD0Wi3vNKe+kpd/q/Of/kw1vA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "722a2b70-1ec9-4ae2-af3d-8b58068ba0d8",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "1122d035-d752-4629-a593-ce22c8958344",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "ef10ef38-336f-495c-bde4-c4af422cb920",
                            CreatedDate = new DateTime(2024, 4, 2, 13, 57, 41, 538, DateTimeKind.Local).AddTicks(6629),
                            Email = "hulya.celebi@bilgeadam.com",
                            EmailConfirmed = false,
                            FirstName = "Hülya",
                            LastName = "Çelebi Yılmaz",
                            LockoutEnabled = false,
                            LoginCount = 0,
                            NormalizedEmail = "HULYA.CELEBI@BILGEADAM.COM",
                            NormalizedUserName = "HULYA.CELEBI",
                            PasswordHash = "AQAAAAIAAYagAAAAEMWUBcIGOPg5E4n2cC3tG3X0tyXAAxwetgSeXLTtbj7dPcJ7wJooVWFM3RHRYKbtTA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dca3d199-23b2-46c0-9438-613e7c8e3e3d",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "hulya.celebi"
                        },
                        new
                        {
                            Id = "94d24825-6148-434a-85b4-259de2b77f3d",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1996, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e6ba60f2-aa5b-4c49-85e4-fd7455c0e665",
                            CreatedDate = new DateTime(2024, 4, 2, 13, 57, 41, 680, DateTimeKind.Local).AddTicks(202),
                            Email = "sinaemre.bekar@bilgeadam.com",
                            EmailConfirmed = false,
                            FirstName = "Sina Emre",
                            LastName = "Bekar",
                            LockoutEnabled = false,
                            LoginCount = 0,
                            NormalizedEmail = "SINAEMRE.BEKAR@BILGEADAM.COM",
                            NormalizedUserName = "SINAEMRE.BEKAR",
                            PasswordHash = "AQAAAAIAAYagAAAAELnXVNgA+h/cEFOSxkB81Qt74JZDjqf63UgDI+iSr2miV+TTc795h2Hqbv1NCsdTUQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "35424aa3-52ea-4f0d-88b4-b4477c3ff358",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "sinaemre.bekar"
                        },
                        new
                        {
                            Id = "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1994, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "7551b6b1-a606-413b-8474-fe09de0056b9",
                            CreatedDate = new DateTime(2024, 4, 2, 13, 57, 41, 802, DateTimeKind.Local).AddTicks(247),
                            Email = "aygun.ziya@bilgeadam.com",
                            EmailConfirmed = false,
                            FirstName = "Ziya",
                            LastName = "Aygün",
                            LockoutEnabled = false,
                            LoginCount = 0,
                            NormalizedEmail = "AYGUN.ZIYA@BILGEADAM.COM",
                            NormalizedUserName = "ZIYA.AYGUN",
                            PasswordHash = "AQAAAAIAAYagAAAAEJfXELbE0Wb4dQ4S06vkK74U1MTLj6rxEWLrN07eGOO1gBN5Vu1//9K7kSca04vhOw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "30bfe208-6c51-4a2c-b61a-0ae1b06527c2",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "ziya.aygun"
                        },
                        new
                        {
                            Id = "428e15d3-3141-4cb0-b245-f0201f6929c7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1991, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "29c19cc3-bcf2-4a87-a59d-e9dd219575f1",
                            CreatedDate = new DateTime(2024, 4, 2, 13, 57, 41, 933, DateTimeKind.Local).AddTicks(1122),
                            Email = "gokce.sporalagoz@bilgeadam.com",
                            EmailConfirmed = false,
                            FirstName = "Gökçe",
                            LastName = "Spor Alagöz",
                            LockoutEnabled = false,
                            LoginCount = 0,
                            NormalizedEmail = "GOKCE.SPORALAGOZ@BILGEADAM.COM",
                            NormalizedUserName = "GOKCE.SPORALAGOZ",
                            PasswordHash = "AQAAAAIAAYagAAAAEG2/U31aOgOQMQj0xm3WOQrMhWRHKWdWhY0dW7mVHTh/SU5Ec16hF9LUCAxX2L0KnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "dd4f7a74-da6d-4209-bf20-2d65f33dcb4c",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "gokce.sporalagoz"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "637e750e-4772-414e-be79-8df14420f11e",
                            Name = "student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "ad02f608-b3f5-43e8-aac6-6f5d8900d493",
                            Name = "teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "2b5d6dba-dba7-4c5d-a24b-16119815bf87",
                            Name = "humanResources",
                            NormalizedName = "HUMANRESOURCES"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "371caecc-777f-4249-8c7d-bbb3f27a73b8",
                            RoleId = "0ad6c1ad-52e4-4f08-9bb2-f477ad1b20f5"
                        },
                        new
                        {
                            UserId = "08f6fd59-a808-46ea-aa80-bc6d85eaa2f9",
                            RoleId = "637e750e-4772-414e-be79-8df14420f11e"
                        },
                        new
                        {
                            UserId = "428e15d3-3141-4cb0-b245-f0201f6929c7",
                            RoleId = "637e750e-4772-414e-be79-8df14420f11e"
                        },
                        new
                        {
                            UserId = "94d24825-6148-434a-85b4-259de2b77f3d",
                            RoleId = "ad02f608-b3f5-43e8-aac6-6f5d8900d493"
                        },
                        new
                        {
                            UserId = "1122d035-d752-4629-a593-ce22c8958344",
                            RoleId = "2b5d6dba-dba7-4c5d-a24b-16119815bf87"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.UserEntities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.UserEntities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Entities.UserEntities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationCore.Entities.UserEntities.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
