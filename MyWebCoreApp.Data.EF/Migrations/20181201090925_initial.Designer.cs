﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebCoreApp.Data.EF;

namespace MyWebCoreApp.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181201090925_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<string>("PositionId")
                        .HasMaxLength(20);

                    b.Property<int?>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AdvertisementPage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementPages");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AdvertisementPosition", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<string>("PageId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("AdvertisementPositions");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AnnouncementUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnouncementId");

                    b.Property<bool?>("HasRead");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("AnnouncementUsers");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar")
                        .HasMaxLength(255);

                    b.Property<decimal>("Balance");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat");

                    b.Property<double?>("Lng");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Other");

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Footer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Function", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("IconCss");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ParentId")
                        .HasMaxLength(128);

                    b.Property<int?>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.GroupSlide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("GroupSlides");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Resources");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillStatus");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("PaymentMethod");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Content");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CanCreate");

                    b.Property<bool>("CanDelete");

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanUpdate");

                    b.Property<string>("FunctionId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("Image")
                        .HasMaxLength(255);

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SeoDescription")
                        .HasMaxLength(255);

                    b.Property<string>("SeoKeywords")
                        .HasMaxLength(255);

                    b.Property<string>("SeoPageTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Status");

                    b.Property<string>("Tags")
                        .HasMaxLength(500);

                    b.Property<string>("ThumbnailImage")
                        .HasMaxLength(255);

                    b.Property<int?>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ParentId");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SeoDescription")
                        .HasMaxLength(255);

                    b.Property<string>("SeoKeywords")
                        .HasMaxLength(255);

                    b.Property<string>("SeoPageTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("ThumbnailImage")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.PostTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId");

                    b.Property<string>("TagId")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Domain");

                    b.Property<bool?>("HomeFlag");

                    b.Property<bool?>("HotFlag");

                    b.Property<string>("ImageList")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<decimal?>("Price");

                    b.Property<decimal?>("PromotionPrice");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SeoDescription")
                        .HasMaxLength(255);

                    b.Property<string>("SeoKeywords")
                        .HasMaxLength(255);

                    b.Property<string>("SeoPageTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Status");

                    b.Property<string>("Tags")
                        .HasMaxLength(500);

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("TypeId");

                    b.Property<int?>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Detail");

                    b.Property<bool?>("HomeFlag");

                    b.Property<int?>("HomeOrder");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ParentId");

                    b.Property<string>("SeoAlias")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("SeoDescription")
                        .HasMaxLength(255);

                    b.Property<string>("SeoKeywords")
                        .HasMaxLength(255);

                    b.Property<string>("SeoPageTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasMaxLength(250);

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductInCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInCategories");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<string>("TagId")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("DisplayOrder");

                    b.Property<int>("GroupId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int?>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.SystemConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Status");

                    b.Property<string>("Value1");

                    b.Property<int?>("Value2");

                    b.Property<bool?>("Value3");

                    b.Property<DateTime?>("Value4");

                    b.Property<decimal?>("Value5");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Advertisement", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.AdvertisementPosition", "AdvertistmentPosition")
                        .WithMany("Advertisements")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AdvertisementPosition", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.AdvertisementPage", "AdvertisementPage")
                        .WithMany("AdvertisementPositions")
                        .HasForeignKey("PageId");
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Announcement", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.AnnouncementUser", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Announcement", "Announcement")
                        .WithMany("AnnouncementUsers")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Order", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWebCoreApp.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Permission", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWebCoreApp.Data.Entities.AppRole", "AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Post", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.PostCategory", "PostCategory")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.PostTag", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWebCoreApp.Data.Entities.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Product", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductImage", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductInCategory", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWebCoreApp.Data.Entities.Product", "Product")
                        .WithMany("ProductInCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.ProductTag", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyWebCoreApp.Data.Entities.Tag", "Tag")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyWebCoreApp.Data.Entities.Slide", b =>
                {
                    b.HasOne("MyWebCoreApp.Data.Entities.GroupSlide", "GroupSlide")
                        .WithMany("Slides")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
