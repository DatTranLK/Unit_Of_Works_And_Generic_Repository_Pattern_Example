using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity.Models
{
    public partial class db_a9c1e6_soleauthenticitydbContext : DbContext
    {
        public db_a9c1e6_soleauthenticitydbContext()
        {
        }

        public db_a9c1e6_soleauthenticitydbContext(DbContextOptions<db_a9c1e6_soleauthenticitydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<New> News { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductSecondHandImage> ProductSecondHandImages { get; set; } = null!;
        public virtual DbSet<RequestSellSecondHand> RequestSellSecondHands { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ShoeCheck> ShoeChecks { get; set; } = null!;
        public virtual DbSet<ShoeCheckImage> ShoeCheckImages { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =SQL8004.site4now.net; database = db_a9c1e6_soleauthenticitydb;uid=db_a9c1e6_soleauthenticitydb_admin;pwd=1234567890@Aa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ParentId).HasColumnName("Parent_Id");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK_Comment_Review");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_Account");
            });

            modelBuilder.Entity<New>(entity =>
            {
                entity.ToTable("New");

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.Context).HasColumnType("ntext");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.ShippingAddress).HasMaxLength(250);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Account1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.OrderStaffs)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Order_Account");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.RequestSecondHand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.RequestSecondHandId)
                    .HasConstraintName("FK_Product_RequestSellSecondHand");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Product_Store");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.ImgPath).HasColumnType("ntext");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductImages_Product");
            });

            modelBuilder.Entity<ProductSecondHandImage>(entity =>
            {
                entity.ToTable("ProductSecondHandImage");

                entity.Property(e => e.ImgPath).HasColumnType("ntext");

                entity.HasOne(d => d.RequestSellSecondHand)
                    .WithMany(p => p.ProductSecondHandImages)
                    .HasForeignKey(d => d.RequestSellSecondHandId)
                    .HasConstraintName("FK_ProductSecondHandImage_RequestSellSecondHand");
            });

            modelBuilder.Entity<RequestSellSecondHand>(entity =>
            {
                entity.ToTable("RequestSellSecondHand");

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(100);

                entity.Property(e => e.PriceBuy)
                    .HasColumnType("money")
                    .HasColumnName("Price_Buy");

                entity.Property(e => e.PriceSell)
                    .HasColumnType("money")
                    .HasColumnName("Price_Sell");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.Quality).HasMaxLength(20);

                entity.Property(e => e.RequestStatus).HasMaxLength(50);

                entity.Property(e => e.Warranty).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestSellSecondHands)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_RequestSellSecondHand_Account");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Review");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Elements).HasColumnType("ntext");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.Review)
                    .HasForeignKey<Review>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Product");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Review_Account");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ShoeCheck>(entity =>
            {
                entity.ToTable("ShoeCheck");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.DateCompletedChecking).HasColumnType("datetime");

                entity.Property(e => e.DateSubmitted).HasColumnType("datetime");

                entity.Property(e => e.ShoeName).HasMaxLength(150);

                entity.Property(e => e.StatusChecking).HasMaxLength(150);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoeCheckCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ShoeCheck_Account1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ShoeCheckStaffs)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ShoeCheck_Account");
            });

            modelBuilder.Entity<ShoeCheckImage>(entity =>
            {
                entity.Property(e => e.ImgPath).HasColumnType("ntext");

                entity.HasOne(d => d.ShoeCheck)
                    .WithMany(p => p.ShoeCheckImages)
                    .HasForeignKey(d => d.ShoeCheckId)
                    .HasConstraintName("FK_ShoeCheckImages_ShoeCheck");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.SizeName).HasMaxLength(150);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Size_Product");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
