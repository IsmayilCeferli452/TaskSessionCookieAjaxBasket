﻿// <auto-generated />
using System;
using FiorelloAsp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiorelloAsp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FiorelloAsp.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9587),
                            Description = "Reshadin Blogu",
                            Image = "blog-feature-img-1.jpg",
                            SoftDeleted = false,
                            Title = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9589),
                            Description = "Ilqarin Blogu",
                            Image = "blog-feature-img-3.jpg",
                            SoftDeleted = false,
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9591),
                            Description = "Hacixanin Blogu",
                            Image = "blog-feature-img-4.jpg",
                            SoftDeleted = false,
                            Title = "Title3"
                        });
                });

            modelBuilder.Entity("FiorelloAsp.Models.BlogImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9671),
                            Image = "h3-team-img-1.png",
                            Role = "Florist",
                            SoftDeleted = false,
                            Title = "CRYSTAL BROOKS"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9673),
                            Image = "h3-team-img-2.png",
                            Role = "Manager",
                            SoftDeleted = false,
                            Title = "SHIRLEY HARRIS"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9675),
                            Image = "h3-team-img-3.png",
                            Role = "Florist",
                            SoftDeleted = false,
                            Title = "BEVERLY CLARK"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9679),
                            Image = "h3-team-img-4.png",
                            Role = "Florist",
                            SoftDeleted = false,
                            Title = "AMANDA WATKINS"
                        });
                });

            modelBuilder.Entity("FiorelloAsp.Models.FooterSocials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Socials");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FiorelloAsp.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9662),
                            Key = "HeaderLogo",
                            SoftDeleted = false,
                            Value = "logo.png"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9663),
                            Key = "Phone",
                            SoftDeleted = false,
                            Value = "12345"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 5, 22, 5, 18, 55, 390, DateTimeKind.Local).AddTicks(9664),
                            Key = "Address",
                            SoftDeleted = false,
                            Value = "Ehmedli"
                        });
                });

            modelBuilder.Entity("FiorelloAsp.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("FiorelloAsp.Models.SliderInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("SliderInfos");
                });

            modelBuilder.Entity("FiorelloAsp.Models.BlogImage", b =>
                {
                    b.HasOne("FiorelloAsp.Models.Blog", "Blog")
                        .WithMany("BlogImages")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Product", b =>
                {
                    b.HasOne("FiorelloAsp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FiorelloAsp.Models.ProductImage", b =>
                {
                    b.HasOne("FiorelloAsp.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Blog", b =>
                {
                    b.Navigation("BlogImages");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FiorelloAsp.Models.Product", b =>
                {
                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
