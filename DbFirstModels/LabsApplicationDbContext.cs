using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LabsApplicationAPI.DbFirstModels
{
    public partial class LabsApplicationDbContext : DbContext
    {
        public LabsApplicationDbContext()
        {
        }

        public LabsApplicationDbContext(DbContextOptions<LabsApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductToCustomerRelation> ProductToCustomerRelations { get; set; } = null!;
        public virtual DbSet<ProductToOrderRelation> ProductToOrderRelations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CVRRHV;Database=LabsApplicationDb;Trusted_Connection=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Age).HasDefaultValueSql("((18))");

                entity.Property(e => e.Country).HasMaxLength(64);

                entity.Property(e => e.EmailAddress).HasMaxLength(64);

                entity.Property(e => e.Firstname).HasMaxLength(64);

                entity.Property(e => e.Lastname).HasMaxLength(64);

                entity.Property(e => e.Password).HasMaxLength(32);

                entity.Property(e => e.ProfilePicture).HasMaxLength(128);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

                entity.HasIndex(e => e.PaymentMethodId, "IX_Orders_PaymentMethodId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(32);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProducerId, "IX_Products_ProducerId");

                entity.Property(e => e.Description).HasDefaultValueSql("(N'512')");

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductType).HasMaxLength(32);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProducerId);
            });

            modelBuilder.Entity<ProductToCustomerRelation>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductId });

                entity.ToTable("ProductToCustomerRelation");

                entity.HasIndex(e => e.ProductId, "IX_ProductToCustomerRelation_ProductId");

                entity.Property(e => e.Amount).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductToCustomerRelations)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductToCustomerRelations)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductToOrderRelation>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("ProductToOrderRelation");

                entity.HasIndex(e => e.ProductId, "IX_ProductToOrderRelation_ProductId");

                entity.Property(e => e.Amount).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductToOrderRelations)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductToOrderRelations)
                    .HasForeignKey(d => d.ProductId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
