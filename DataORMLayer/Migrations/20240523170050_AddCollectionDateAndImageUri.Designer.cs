﻿// <auto-generated />
using System;
using DataORMLayer.EfCoreCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataORMLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240523170050_AddCollectionDateAndImageUri")]
    partial class AddCollectionDateAndImageUri
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataORMLayer.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DataORMLayer.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Movies"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Books"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Clothes"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Games, Toys, and Figures"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Bills and Coins, Stamps"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Music Albums, Clips, and Records"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Product and Service Reviews"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Cars and Vehicles"
                        },
                        new
                        {
                            CategoryId = 9,
                            Name = "Dish Recipes"
                        },
                        new
                        {
                            CategoryId = 10,
                            Name = "Firearms"
                        },
                        new
                        {
                            CategoryId = 99,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.Collection", b =>
                {
                    b.Property<Guid>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CollectionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");

                    b.HasData(
                        new
                        {
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            CategoryId = 1,
                            CreateDate = new DateTime(2024, 5, 23, 17, 0, 50, 341, DateTimeKind.Utc).AddTicks(1594),
                            Description = "The description of the \"IMDb top 10 movies\" collection",
                            Name = "IMDb top 10 movies",
                            UserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3"
                        },
                        new
                        {
                            CollectionId = new Guid("6a2d56c8-2450-4504-b0a1-77f884f403b2"),
                            CategoryId = 2,
                            CreateDate = new DateTime(2024, 5, 23, 17, 0, 50, 341, DateTimeKind.Utc).AddTicks(1595),
                            Description = "A Torah, a Bible, and a Qur’an",
                            Name = "Art of Three Faiths",
                            UserId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3"
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.CollectionField", b =>
                {
                    b.Property<Guid>("CollectionFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FieldType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionFieldId");

                    b.HasIndex("CollectionId");

                    b.ToTable("CollectionFields");

                    b.HasData(
                        new
                        {
                            CollectionFieldId = new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            FieldName = "Movie Title",
                            FieldType = "String"
                        },
                        new
                        {
                            CollectionFieldId = new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            FieldName = "IMDb Score",
                            FieldType = "Integer"
                        },
                        new
                        {
                            CollectionFieldId = new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            FieldName = "Relise date",
                            FieldType = "Date"
                        },
                        new
                        {
                            CollectionFieldId = new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            FieldName = "Move plot",
                            FieldType = "Text"
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.BooleanField", b =>
                {
                    b.Property<Guid>("BooleanFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasKey("BooleanFieldId");

                    b.HasIndex("CollectionFieldId");

                    b.HasIndex("ItemId");

                    b.ToTable("BooleanFields");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.DateField", b =>
                {
                    b.Property<Guid>("DateFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Value")
                        .HasColumnType("date");

                    b.HasKey("DateFieldId");

                    b.HasIndex("CollectionFieldId");

                    b.HasIndex("ItemId");

                    b.ToTable("DateFields");

                    b.HasData(
                        new
                        {
                            DateFieldId = new Guid("0591592d-2df3-4456-bc89-e46d86f24f10"),
                            CollectionFieldId = new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"),
                            ItemId = new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"),
                            Value = new DateOnly(1994, 1, 1)
                        },
                        new
                        {
                            DateFieldId = new Guid("9d38dbbb-d396-43e3-b73c-468e22c7192b"),
                            CollectionFieldId = new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"),
                            ItemId = new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"),
                            Value = new DateOnly(1972, 1, 1)
                        },
                        new
                        {
                            DateFieldId = new Guid("9e321b41-76ff-44cc-a6a7-7aac581224ba"),
                            CollectionFieldId = new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"),
                            ItemId = new Guid("df9618db-732e-4057-a849-9cff40a72e4d"),
                            Value = new DateOnly(2008, 1, 1)
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.IntegerField", b =>
                {
                    b.Property<Guid>("IntegerFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("IntegerFieldId");

                    b.HasIndex("CollectionFieldId");

                    b.HasIndex("ItemId");

                    b.ToTable("IntegerFields");

                    b.HasData(
                        new
                        {
                            IntegerFieldId = new Guid("4d4d9886-711b-43a1-b309-11eb30cdb448"),
                            CollectionFieldId = new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"),
                            ItemId = new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"),
                            Value = 93
                        },
                        new
                        {
                            IntegerFieldId = new Guid("a287ed46-caf4-4003-95fb-973f05bcb5a0"),
                            CollectionFieldId = new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"),
                            ItemId = new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"),
                            Value = 92
                        },
                        new
                        {
                            IntegerFieldId = new Guid("c78a3c8a-dcfc-4996-8a38-6550cf3f3662"),
                            CollectionFieldId = new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"),
                            ItemId = new Guid("df9618db-732e-4057-a849-9cff40a72e4d"),
                            Value = 90
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.StringField", b =>
                {
                    b.Property<Guid>("StringFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("StringFieldId");

                    b.HasIndex("CollectionFieldId");

                    b.HasIndex("ItemId");

                    b.ToTable("StringFields");

                    b.HasData(
                        new
                        {
                            StringFieldId = new Guid("e66f388a-c59f-407d-b1c2-d0de8f96fd6f"),
                            CollectionFieldId = new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"),
                            ItemId = new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"),
                            Value = "The Shawshank Redemption"
                        },
                        new
                        {
                            StringFieldId = new Guid("a8eb5afb-17de-4067-b964-7ce3296b2815"),
                            CollectionFieldId = new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"),
                            ItemId = new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"),
                            Value = "The Godfather"
                        },
                        new
                        {
                            StringFieldId = new Guid("19faf591-060b-467e-aa9c-f4209f5758fc"),
                            CollectionFieldId = new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"),
                            ItemId = new Guid("df9618db-732e-4057-a849-9cff40a72e4d"),
                            Value = "The Dark Knight"
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.TextField", b =>
                {
                    b.Property<Guid>("TextFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionFieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("TextFieldId");

                    b.HasIndex("CollectionFieldId");

                    b.HasIndex("ItemId");

                    b.ToTable("TextFields");

                    b.HasData(
                        new
                        {
                            TextFieldId = new Guid("ec62a8c4-b5ad-44ec-b5f3-2797b22f323f"),
                            CollectionFieldId = new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"),
                            ItemId = new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"),
                            Value = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."
                        },
                        new
                        {
                            TextFieldId = new Guid("0a4f1ad8-2df4-446c-a949-6164c3ef31f1"),
                            CollectionFieldId = new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"),
                            ItemId = new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"),
                            Value = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                        },
                        new
                        {
                            TextFieldId = new Guid("f86bf397-5907-4a16-88ed-a6b8287b6b82"),
                            CollectionFieldId = new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"),
                            ItemId = new Guid("df9618db-732e-4057-a849-9cff40a72e4d"),
                            Value = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("ItemId");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            Name = "First position"
                        },
                        new
                        {
                            ItemId = new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            Name = "Second position"
                        },
                        new
                        {
                            ItemId = new Guid("df9618db-732e-4057-a849-9cff40a72e4d"),
                            CollectionId = new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"),
                            Name = "3rd position"
                        });
                });

            modelBuilder.Entity("DataORMLayer.Models.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.Property<Guid>("ItemsItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagsTagId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemsItemId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("ItemTag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataORMLayer.Models.Collection", b =>
                {
                    b.HasOne("DataORMLayer.Models.Category", "Category")
                        .WithMany("Collections")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataORMLayer.Models.CollectionField", b =>
                {
                    b.HasOne("DataORMLayer.Models.Collection", "Collection")
                        .WithMany("CollectionFields")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.BooleanField", b =>
                {
                    b.HasOne("DataORMLayer.Models.CollectionField", "CollectionField")
                        .WithMany()
                        .HasForeignKey("CollectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Item", "Item")
                        .WithMany("BooleanFields")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionField");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.DateField", b =>
                {
                    b.HasOne("DataORMLayer.Models.CollectionField", "CollectionField")
                        .WithMany()
                        .HasForeignKey("CollectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Item", "Item")
                        .WithMany("DateFields")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionField");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.IntegerField", b =>
                {
                    b.HasOne("DataORMLayer.Models.CollectionField", "CollectionField")
                        .WithMany()
                        .HasForeignKey("CollectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Item", "Item")
                        .WithMany("IntegerFields")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionField");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.StringField", b =>
                {
                    b.HasOne("DataORMLayer.Models.CollectionField", "CollectionField")
                        .WithMany()
                        .HasForeignKey("CollectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Item", "Item")
                        .WithMany("StringFields")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionField");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataORMLayer.Models.CustomDataFields.TextField", b =>
                {
                    b.HasOne("DataORMLayer.Models.CollectionField", "CollectionField")
                        .WithMany()
                        .HasForeignKey("CollectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Item", "Item")
                        .WithMany("TextFields")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CollectionField");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("DataORMLayer.Models.Item", b =>
                {
                    b.HasOne("DataORMLayer.Models.Collection", "Collection")
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.HasOne("DataORMLayer.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataORMLayer.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("DataORMLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataORMLayer.Models.ApplicationUser", null)
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

                    b.HasOne("DataORMLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataORMLayer.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataORMLayer.Models.ApplicationUser", b =>
                {
                    b.Navigation("Collections");
                });

            modelBuilder.Entity("DataORMLayer.Models.Category", b =>
                {
                    b.Navigation("Collections");
                });

            modelBuilder.Entity("DataORMLayer.Models.Collection", b =>
                {
                    b.Navigation("CollectionFields");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("DataORMLayer.Models.Item", b =>
                {
                    b.Navigation("BooleanFields");

                    b.Navigation("DateFields");

                    b.Navigation("IntegerFields");

                    b.Navigation("StringFields");

                    b.Navigation("TextFields");
                });
#pragma warning restore 612, 618
        }
    }
}