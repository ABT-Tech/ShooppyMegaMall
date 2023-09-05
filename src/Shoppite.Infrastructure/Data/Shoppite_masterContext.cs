using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shoppite.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Shoppite.Infrastructure.Data
{
    public partial class Shoppite_masterContext : DbContext
    {
        public Shoppite_masterContext()
        {
        }

        public Shoppite_masterContext(DbContextOptions<Shoppite_masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdsDetail> AdsDetail { get; set; }
        public virtual DbSet<AdsPageName> AdsPageName { get; set; }
        public virtual DbSet<AdsPlacement> AdsPlacement { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AttributesSetup> AttributesSetup { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<CategoryOne> CategoryOne { get; set; }
        public virtual DbSet<CategoryThree> CategoryThree { get; set; }
        public virtual DbSet<CategoryTwo> CategoryTwo { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CustomerWishlist> CustomerWishlist { get; set; }
        public virtual DbSet<DonationMaster> DonationMaster { get; set; }
        public virtual DbSet<DonationReceived> DonationReceived { get; set; }
        public virtual DbSet<EmailSetup> EmailSetup { get; set; }
        public virtual DbSet<Logo> Logo { get; set; }
        public virtual DbSet<MainPageCategory> MainPageCategory { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NewsLetter> NewsLetter { get; set; }
        public virtual DbSet<OrderBasic> OrderBasic { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderDisbursement> OrderDisbursement { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<OrderShipping> OrderShipping { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderVariation> OrderVariation { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationAggregatorControl> OrganizationAggregatorControls { get; set; }
        public virtual DbSet<PageCategory> PageCategory { get; set; }
        public virtual DbSet<PageCategoryDetails> PageCategoryDetails { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        public virtual DbSet<ProductBasic> ProductBasic { get; set; }
        public virtual DbSet<ProductBrands> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscount { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<ProductInventory> ProductInventory { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ProductRecentlyViewed> ProductRecentlyViewed { get; set; }
        public virtual DbSet<ProductSeo> ProductSeo { get; set; }
        public virtual DbSet<ProductSpecification> ProductSpecification { get; set; }
        public virtual DbSet<ProductStatus> ProductStatus { get; set; }
        public virtual DbSet<ProductTags> ProductTags { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<SpecificationSetup> SpecificationSetup { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserActivation> UserActivation { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersMembership> UsersMembership { get; set; }
        public virtual DbSet<UsersProfile> UsersProfile { get; set; }
        public virtual DbSet<VendorMembershipPackage> VendorMembershipPackage { get; set; }
        public virtual DbSet<WebsiteSetup> WebsiteSetup { get; set; }
        public virtual DbSet<WebsiteSetupScript> WebsiteSetupScript { get; set; }
        public virtual DbSet<sp_getcat_Result> Sp_Getcat_Results { get; set; }
        public virtual DbSet<SP_Status_HasProducts_Result> SP_Status_hasProducts_results { get; set; }
        public virtual DbSet<F_Topcat_Result> F_Topcat_Results { get; set; }
        public virtual DbSet<f_getproducts_By_NewArrivals> F_Getproducts_By_NewArrivals { get; set; }
        public virtual DbSet<f_getproducts_By_OrgID> F_Getproducts_By_OrgID { get; set; }
        public virtual DbSet<f_getproducts_By_CategoryID> F_Getproducts_By_CategoryID { get; set; }
        public virtual DbSet<f_getproducts_By_CategoryID_Result> f_getproducts_By_CategoryID_Result { get; set; }
        public virtual DbSet<f_All_getcat_Result> f_All_getcat_Result { get; set; }
        public virtual DbSet<SP_GetSpecificationData_AttributName> SP_GetSpecificationData_AttributName { get; set; }
        public virtual DbSet<f_getproducts_By_CatID_SpecificationName> F_Getproducts_By_CatID_SpecificationName { get; set; }
        public virtual DbSet<SP_UserWishList> SP_UserWishList { get; set; }
        public virtual DbSet<F_Orders_All> F_Orders_All { get; set; }
        public virtual DbSet<F_Pending_Orders> F_Pending_Orders { get; set; }
        public virtual DbSet<f_Get_MyAccount_Data> f_Get_MyAccount_Data { get; set; }
        public virtual DbSet<F_getproducts_By_CatId> F_getproducts_By_CatId { get; set; }
        public virtual DbSet<F_getproducts_By_BrandId> F_getproducts_By_BrandId { get; set; }
        public virtual DbSet<f_getproducts_Recentlyviewed> f_Getproducts_Recentlyviewed { get; set; }
        public virtual DbSet<f_getproduct_specification_By_Guid> GetF_Getproduct_Specification_By_Guid { get; set; }
        public virtual DbSet<f_getproduct_CartDetails_By_Orgid> F_Getproduct_CartDetails_By_Orgid { get; set; }
        public virtual DbSet<f_order_master> F_Order_Master { get; set; }
        public virtual DbSet<f_order_masterDetails> f_order_masterDetails { get; set; }
        public virtual DbSet<ProductVariant> ProductVariant { get; set; }
        public virtual DbSet<f_getproduct_varient_By_Guid> F_Getproduct_Varient_By_Guid { get; set; }
        public virtual DbSet<SP_GetProductDetails> SP_GetProductDetails { get; set; }
        public virtual DbSet<SP_GetProductSpecifications> SP_GetProductSpecifications { get; set; }
        public virtual DbSet<WhatsAppMessages> WhatsAppMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=103.150.186.216;Initial Catalog=Shoppite_master;User ID=sa;Password=Z8Lix[jg3K@R74;MultipleActiveResultSets=True;Application Name=EntityFramework");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-40G3LDG;Initial Catalog=Shoppite_master;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdsDetail>(entity =>
            {
                entity.HasKey(e => e.AdId);

                entity.ToTable("Ads_Detail");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);

            });

            modelBuilder.Entity<AdsPageName>(entity =>
            {
                entity.HasKey(e => e.AdsPageId);

                entity.ToTable("Ads_PageName");

                entity.Property(e => e.PageName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<AdsPlacement>(entity =>
            {
                entity.ToTable("Ads_Placement");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.PlacementName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AttributesSetup>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PK_Attributes");

                entity.ToTable("Attributes_Setup");

                entity.Property(e => e.AttributeDescription).HasMaxLength(500);

                entity.Property(e => e.AttributeName).HasMaxLength(200);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandImage).HasMaxLength(1000);

                entity.Property(e => e.BrandName).HasMaxLength(200);

                entity.Property(e => e.BrandUrlpath)
                    .HasColumnName("BrandURLPath")
                    .HasMaxLength(500);

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("category_master");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Banner).HasMaxLength(1000);

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(200);

                entity.Property(e => e.Icon).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

                entity.Property(e => e.SeoDescription)
                    .HasColumnName("SEO_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.SeoKeyword)
                    .HasColumnName("SEO_Keyword")
                    .HasMaxLength(1000);

                entity.Property(e => e.SeoPageName)
                    .HasColumnName("SEO_PageName")
                    .HasMaxLength(100);

                entity.Property(e => e.SeoTitle)
                    .HasColumnName("SEO_Title")
                    .HasMaxLength(100);

                entity.Property(e => e.Urlpath)
                    .HasColumnName("URLPath")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CategoryOne>(entity =>
            {
                entity.ToTable("Category_One");

                entity.Property(e => e.Banner).HasMaxLength(500);

                entity.Property(e => e.CategoryName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.IsFeatured).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UrlPath).HasMaxLength(300);
            });

            modelBuilder.Entity<CategoryThree>(entity =>
            {
                entity.ToTable("Category_Three");

                entity.Property(e => e.Banner).HasMaxLength(500);

                entity.Property(e => e.CategoryThreeName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.IsFeatured).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UrlPath).HasMaxLength(300);
            });

            modelBuilder.Entity<CategoryTwo>(entity =>
            {
                entity.ToTable("Category_Two");

                entity.Property(e => e.Banner).HasMaxLength(500);

                entity.Property(e => e.CategoryTwoName).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.IsFeatured).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UrlPath).HasMaxLength(300);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryName).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(2000);

                entity.Property(e => e.InsertBy).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.Isbase).HasColumnName("ISBase");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CustomerWishlist>(entity =>
            {
                entity.HasKey(e => e.WishlistId);

                entity.ToTable("Customer_Wishlist");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<DonationMaster>(entity =>
            {
                entity.HasKey(e => e.RequestFundId);

                entity.ToTable("Donation_Master");

                entity.Property(e => e.AdminRemarks).HasMaxLength(1000);

                entity.Property(e => e.Administrativefee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.PaypalId)
                    .HasColumnName("PaypalID")
                    .HasMaxLength(256);

                entity.Property(e => e.RequestFundGuid)
                    .HasColumnName("RequestFundGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Title).HasMaxLength(1000);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<DonationReceived>(entity =>
            {
                entity.ToTable("Donation_Received");

                entity.Property(e => e.AdministrativeAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AdministrativeFeesPer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaypalId).HasMaxLength(256);

                entity.Property(e => e.RequestFundGuid).HasColumnName("RequestFundGUID");
            });

            modelBuilder.Entity<EmailSetup>(entity =>
            {
                entity.HasKey(e => e.EmailSettingId);

                entity.ToTable("Email_Setup");

                entity.Property(e => e.Bcc)
                    .HasColumnName("BCC")
                    .HasMaxLength(256);

                entity.Property(e => e.EmailFrom).HasMaxLength(256);

                entity.Property(e => e.Host).HasMaxLength(500);

                entity.Property(e => e.Password).HasMaxLength(300);

                entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Logo>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Favicon).HasMaxLength(1000);

                entity.Property(e => e.FooterLogo).HasMaxLength(1000);

                entity.Property(e => e.Keyword).HasMaxLength(1000);

                entity.Property(e => e.Logo1)
                    .HasColumnName("Logo")
                    .HasMaxLength(1000);

                entity.Property(e => e.Logoheight).HasColumnName("logoheight");

                entity.Property(e => e.Logowidth).HasColumnName("logowidth");

                entity.Property(e => e.SupportContact).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(1000);

                entity.Property(e => e.WebsiteName).HasMaxLength(50);
            });

            modelBuilder.Entity<MainPageCategory>(entity =>
            {
                entity.Property(e => e.MainPageCategory1)
                    .HasColumnName("MainPageCategory")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MesageId);

                entity.Property(e => e.Attachment).HasMaxLength(3000);

                entity.Property(e => e.ChatId)
                    .HasColumnName("ChatID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Message).HasMaxLength(4000);

                entity.Property(e => e.Recieveddate)
                    .HasColumnName("recieveddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Recipient)
                    .HasColumnName("recipient")
                    .HasMaxLength(256);

                entity.Property(e => e.Senddate)
                    .HasColumnName("senddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasMaxLength(256);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NewsLetter>(entity =>
            {
                entity.Property(e => e.NewsletterId).HasColumnName("NewsletterID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderBasic>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Order_Basic");

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.DeliveryFees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Donation).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.LastOrderStatus).HasMaxLength(50);

                entity.Property(e => e.OrderGuid)
                    .HasColumnName("OrderGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.OrderVariation).HasMaxLength(2000);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.ReferenceId)
                    .HasColumnName("ReferenceID")
                    .HasMaxLength(50);

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Detail");

                entity.Property(e => e.DeliveryFees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderGuid).HasColumnName("OrderGUID");

                entity.Property(e => e.TotalOrderAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderDisbursement>(entity =>
            {
                entity.HasKey(e => e.OrderEarningId);

                entity.ToTable("Order_Disbursement");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DisburseDate).HasColumnType("datetime");

                entity.Property(e => e.DisbursementId).HasMaxLength(500);

                entity.Property(e => e.DisbursementMode).HasMaxLength(50);

                entity.Property(e => e.InsertBy).HasMaxLength(256);
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.HasKey(e => e.OrderGuid);

                entity.ToTable("Order_Master");

                entity.Property(e => e.OrderGuid)
                    .HasColumnName("OrderGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsertDate).HasColumnType("date");

                entity.Property(e => e.OrderKeyStatus).HasMaxLength(20);
            });

            modelBuilder.Entity<OrderShipping>(entity =>
            {
                entity.HasKey(e => e.ShippingId);

                entity.ToTable("Order_Shipping");

                entity.Property(e => e.Address).HasMaxLength(2000);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Contactnumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.OrderGuid).HasColumnName("OrderGUID");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.Zipcode).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.Property(e => e.Insertby).HasMaxLength(256);

                entity.Property(e => e.OrderStatus1)
                    .HasColumnName("OrderStatus")
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.StatusDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderVariation>(entity =>
            {
                entity.ToTable("Order_Variation");

                entity.Property(e => e.OrderGuid).HasColumnName("OrderGUID");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgAddress)
                    .HasColumnName("org_address")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.OrgDescription)
                    .HasColumnName("org_description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.OrgLogo)
                    .HasColumnName("org_logo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgName)
                    .HasColumnName("org_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VAccountNumber)
                    .HasColumnName("v_account_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VBankBranchName)
                    .HasColumnName("v_bank_branch_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VBankName)
                    .HasColumnName("v_bank_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VEmail)
                    .HasColumnName("v_email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VIdProof)
                    .HasColumnName("v_id_proof")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VIfscCode)
                    .HasColumnName("v_ifsc_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VMobile)
                    .HasColumnName("v_mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VPhone)
                    .HasColumnName("v_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VUpiId)
                    .HasColumnName("v_upi_id")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VenderName)
                    .HasColumnName("vender_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PageCategory>(entity =>
            {
                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.IsUrl).HasColumnName("IsURL");

                entity.Property(e => e.PageCategory1)
                    .HasColumnName("PageCategory")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PageCategoryDetails>(entity =>
            {
                entity.HasKey(e => e.PageCategoryDetailId)
                    .HasName("PK_PageCategoryDetail");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("Product_Attribute");

                entity.Property(e => e.ProductAttributeId).HasColumnName("ProductAttributeID");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductBasic>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product_Basic");

                entity.Property(e => e.CoverImage).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductStartDate).HasColumnType("datetime");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.ShortDescription).HasMaxLength(500);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(200);

                entity.Property(e => e.Urlpath)
                    .HasColumnName("URLPath")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductBrands>(entity =>
            {
                entity.HasKey(e => e.ProductBrandId)
                    .HasName("PK_Product_Brand");

                entity.ToTable("Product_Brands");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.MainCatId).HasColumnName("MainCat_Id");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductDiscount>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("Product_Discount");

                entity.Property(e => e.DiscountEndDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountOffer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DiscountStartDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountType).HasMaxLength(20);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasMaxLength(100);

                entity.Property(e => e.ModuleType).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.ToTable("Product_Images");

                entity.Property(e => e.AltText).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductInventory>(entity =>
            {
                entity.ToTable("Product_Inventory");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.ToTable("Product_Price");

                entity.Property(e => e.DeliveryFees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");
            });

            modelBuilder.Entity<ProductRecentlyViewed>(entity =>
            {
                entity.HasKey(e => e.RecentlyViewId);

                entity.ToTable("Product_Recently_Viewed");

                entity.Property(e => e.Insertdate).HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductSeo>(entity =>
            {
                entity.HasKey(e => e.Seoid);

                entity.ToTable("Product_SEO");

                entity.Property(e => e.Seoid).HasColumnName("SEOId");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.SeoKeywords)
                    .HasColumnName("SEO_Keywords")
                    .HasMaxLength(500);

                entity.Property(e => e.SeoMetaTitle)
                    .HasColumnName("SEO_MetaTItle")
                    .HasMaxLength(500);

                entity.Property(e => e.SeoMetadescription)
                    .HasColumnName("SEO_Metadescription")
                    .HasMaxLength(1000);

                entity.Property(e => e.SeoPageName)
                    .HasColumnName("SEO_PageName")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ProductSpecification>(entity =>
            {
                entity.ToTable("Product_Specification");

                entity.Property(e => e.ControlType).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.Insertdate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductStatus>(entity =>
            {
                entity.ToTable("Product_Status");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProductTags>(entity =>
            {
                entity.ToTable("Product_Tags");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ProductGuid).HasColumnName("ProductGUID");

                entity.Property(e => e.ProductTags1)
                    .HasColumnName("ProductTags")
                    .HasMaxLength(3000);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Module).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(4000);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<SpecificationSetup>(entity =>
            {
                entity.HasKey(e => e.SpecificationId);

                entity.ToTable("Specification_Setup");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpecificationName).HasMaxLength(200);

                entity.Property(e => e.SpecificiatoinDescription).HasMaxLength(500);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.CssClass).HasMaxLength(1000);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Status1)
                    .HasColumnName((string)"Status")
                    .HasMaxLength((int)50);

                entity.Property(e => e.Urlpath)
                    .HasColumnName("URLPath")
                    .HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserActivation>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UsersMembership>(entity =>
            {
                entity.HasKey(e => e.MembershipId);

                entity.ToTable("Users_Membership");

                entity.Property(e => e.CancelStatus).HasMaxLength(50);

                entity.Property(e => e.Cancellationdate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.MembershipFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MembershipStatus).HasMaxLength(50);

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.ReferenceId).HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UsersProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("Users_Profile");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.AdminStatus).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CoverImage).HasMaxLength(200);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(100);

                entity.Property(e => e.Logo).HasMaxLength(200);

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasMaxLength(100);

                entity.Property(e => e.PaypalId).HasMaxLength(256);

                entity.Property(e => e.ProfileGuid)
                    .HasColumnName("ProfileGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ShopDescription).HasMaxLength(2000);

                entity.Property(e => e.ShopName).HasMaxLength(200);

                entity.Property(e => e.ShopUrlpath)
                    .HasColumnName("ShopURLPath")
                    .HasMaxLength(500);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            modelBuilder.Entity<VendorMembershipPackage>(entity =>
            {
                entity.HasKey(e => e.Membershipid)
                    .HasName("PK_Vendor_Membership");

                entity.ToTable("Vendor_Membership_Package");

                entity.Property(e => e.Fees).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Membershiptype).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Unit).HasMaxLength(50);
            });

            modelBuilder.Entity<WebsiteSetup>(entity =>
            {
                entity.ToTable("Website_Setup");

                entity.Property(e => e.DeductionType).HasMaxLength(10);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasMaxLength(500);

                entity.Property(e => e.ItemKey).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ItemValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<WebsiteSetupScript>(entity =>
            {
                entity.HasKey(e => e.Scriptid);

                entity.ToTable("Website_Setup_Script");

                entity.Property(e => e.Scriptname).HasMaxLength(2000);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(30);
            });
            modelBuilder.Entity<WhatsAppMessages>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("WhatsAppMessages");

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.MessageRequest).HasMaxLength(2000);

                entity.Property(e => e.TemplateID).HasMaxLength(50);

                entity.Property(e => e.Is_SendMessage).HasColumnName("Is_SendMessage");

                entity.Property(e => e.MessageRequest).HasMaxLength(2000);

                entity.Property(e => e.MessageResponse).HasMaxLength(2000);

                entity.Property(e => e.OrgName).HasMaxLength(100);

                entity.Property(e => e.InsertDateTime).HasColumnType("datetime");

            });

            modelBuilder.Entity<OrganizationAggregatorControl>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Organization_Aggregator_Control");
            });

            modelBuilder.Entity<SP_Status_HasProducts_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproducts_By_NewArrivals>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<f_getproducts_By_OrgID>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproducts_By_CategoryID>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproducts_By_CategoryID_Result>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_GetSpecificationData_AttributName>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproducts_Recentlyviewed>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproduct_specification_By_Guid>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_getproduct_CartDetails_By_Orgid>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<f_getproducts_By_CatID_SpecificationName>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_UserWishList>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<F_Orders_All>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<F_Pending_Orders>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_Get_MyAccount_Data>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<F_getproducts_By_CatId>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<F_getproducts_By_BrandId>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_order_master>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<f_order_masterDetails>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product_Variant");
            });
            modelBuilder.Entity<f_getproduct_varient_By_Guid>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_GetProductDetails>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<SP_GetProductSpecifications>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
