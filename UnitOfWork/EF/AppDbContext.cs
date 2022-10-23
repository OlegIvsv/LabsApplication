using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LabsApplication.UnitOfWork.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabsApplication.UnitOfWork.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public DbSet<Producer> Producers => Set<Producer>();

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

        public DbSet<ProductToOrder> ProductToOrders => Set<ProductToOrder>();

        public DbSet<ProductToCustomer> ProductToCustomer => Set<ProductToCustomer>();


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProducerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        class CustomerConfiguration : IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                builder.ToTable("Customers");

                builder.HasKey(c => c.Id);
                builder.HasMany(c => c.Products)
                    .WithMany(p => p.Customers)
                    .UsingEntity<ProductToCustomer>(
                        e => e
                        .HasOne(e => e.Product)
                        .WithMany(p => p.ProductToCustomers)
                        .HasForeignKey(e => e.ProductId)
                        .HasPrincipalKey(p => p.Id),
                        e => e
                        .HasOne(e => e.Customer)
                        .WithMany(c => c.ProductToCustomers)
                        .HasForeignKey(c => c.CustomerId)
                        .HasPrincipalKey(c => c.Id),
                        e =>
                        {
                            e.ToTable("ProductToCustomerRelation");
                            e.HasKey(i => new { i.CustomerId, i.ProductId });
                            e.Property(i => i.Amount).HasDefaultValue(1);
                        }
                    );

                builder.Property(c => c.Firstname).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(c => c.Lastname).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(c => c.Age).HasDefaultValue(18);
                builder.Property(c => c.Country).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(c => c.Gender).IsRequired(false);
                builder.Property(c => c.EmailAddress).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(c => c.Password).HasColumnType("nvarchar").HasMaxLength(32);
                builder.Property(c => c.ProfilePicture).HasColumnType("nvarchar").HasMaxLength(128);
            }
        }

        class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.ToTable("Products");

                builder.HasKey(p => p.Id);
                builder.HasOne(p => p.Producer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ProducerId)
                    .HasPrincipalKey(p => p.Id);

                builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(p => p.ProductType).HasColumnType("nvarchar").HasMaxLength(32).IsRequired(false);
                builder.Property(p => p.Description).HasDefaultValue(512).IsRequired(false);
                builder.Property(p => p.Price).HasColumnType("money");
                builder.Property(p => p.Amount).HasDefaultValue(0);
            }
        }

        class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.ToTable("Orders");

                builder.HasKey(o => o.Id);
                builder.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId)
                    .HasPrincipalKey(c => c.Id);
                builder.HasOne(o => o.PaymentMethod)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(o => o.PaymentMethodId)
                  .HasPrincipalKey(p => p.Id);
                builder.HasMany(o => o.Products)
                    .WithMany(o => o.Orders)
                    .UsingEntity<ProductToOrder>(
                        e => e
                        .HasOne(e => e.Product)
                        .WithMany(p => p.ProductToOrders)
                        .HasForeignKey(e => e.ProductId)
                        .HasPrincipalKey(p => p.Id),
                        e => e
                        .HasOne(e => e.Order)
                        .WithMany(o => o.ProductToOrders)
                        .HasForeignKey(e => e.OrderId)
                        .HasPrincipalKey(o => o.Id),
                        e =>
                        {
                            e.ToTable("ProductToOrderRelation");
                            e.HasKey(i => new { i.OrderId, i.ProductId });
                            e.Property(i => i.Amount).HasDefaultValue(1);
                        }
                    );
            }
        }

        class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
        {
            public void Configure(EntityTypeBuilder<PaymentMethod> builder)
            {
                builder.ToTable("PaymentMethods");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(64);
            }
        }

        class ProducerConfiguration : IEntityTypeConfiguration<Producer>
        {
            public void Configure(EntityTypeBuilder<Producer> builder)
            {
                builder.ToTable("Producers");

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(64);
                builder.Property(p => p.Description).HasColumnType("nvarchar").HasMaxLength(256);
                builder.Property(p => p.Country).HasColumnType("nvarchar").HasMaxLength(32);
            }
        }
    }
}
