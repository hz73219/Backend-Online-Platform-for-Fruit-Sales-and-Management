using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class FruitContext : DbContext
    {
        public FruitContext()
        {

        }
        public FruitContext(DbContextOptions<FruitContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Product");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(x => x.Quantity).IsRequired();
                builder.Property(x => x.Note).HasMaxLength(1000);
                builder.Property(x => x.Detail).HasColumnType("NVARCHAR(MAX)");
                builder.Property(x => x.IdImage).IsRequired().HasMaxLength(50);
                builder.Property(x => x.CreateDay).IsRequired().HasColumnType("datetime");
                builder.Property(x => x.SoldQuantity).IsRequired();
                builder.HasMany(p => p.Images)
                  .WithOne()
                  .HasForeignKey(i => i.Parent)
                  .HasPrincipalKey(p => p.IdImage)
                  .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Origin>(builder =>
            {
                builder.ToTable("Origin");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

                builder.HasMany(p => p.List_Product)
                  .WithOne()
                  .HasForeignKey(i => i.IdOrigin)
                  .HasPrincipalKey(p => p.Id)
                  .IsRequired(false);

            });

            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Category");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

                builder.HasMany(p => p.List_Product)
                 .WithOne()
                 .HasForeignKey(i => i.IdCategory)
                 .HasPrincipalKey(p => p.Id)
                 .IsRequired(false);
                ;
            });

            modelBuilder.Entity<Image>(builder =>
            {
                builder.ToTable("Image");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Path).IsRequired().HasMaxLength(250);
                builder.Property(x => x.Name_Old).IsRequired().HasMaxLength(250);
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.ToTable("Cart");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.IdProduct).IsRequired().HasMaxLength(50);
                builder.Property(x => x.IdUser).IsRequired().HasMaxLength(50);
                builder.Property(x => x.Quantity).IsRequired();
                builder.HasOne(x => x.Product)
                    .WithMany()
                    .HasForeignKey(x => x.IdProduct);
            });

            modelBuilder.Entity<OrderDetail>(builder =>
            {
                builder.ToTable("OrderDetail");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Quantity).IsRequired();
                builder.Property(x => x.Price).IsRequired();
                builder.HasOne(x => x.Product)
                    .WithMany()
                    .HasForeignKey(x => x.IdProduct);
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Order");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.TotalPrice).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(x => x.PriceDiscount).IsRequired().HasColumnType("decimal(18, 2)");
                builder.Property(x => x.Status).IsRequired();
                builder.Property(x => x.CreateDay).IsRequired().HasColumnType("datetime");
                builder.Property(x => x.FinishDay).HasColumnType("datetime");
                builder.Property(x => x.PhoneNumber).HasMaxLength(12);
                builder.Property(x => x.Address).HasColumnType("nvarchar").HasMaxLength(500);
                builder.Property(x => x.FullName).HasMaxLength(255);

                builder.HasMany(c => c.ListOrderDetail)
                    .WithOne()
                    .HasForeignKey(p => p.IdOrder)
                    .HasPrincipalKey(c => c.Id);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("User");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
                builder.Property(x => x.FullName).HasMaxLength(255);
                builder.Property(x => x.Role).HasMaxLength(255);
                builder.Property(x => x.Email).HasMaxLength(255);
                builder.Property(x => x.Phone).HasMaxLength(255);
                builder.Property(x => x.Address).HasColumnType("nvarchar").HasMaxLength(500);
                builder.HasMany(u => u.ListOrder)
                    .WithOne()
                    .HasForeignKey(o => o.IdUser)
                    .HasPrincipalKey(u => u.Id);
                builder.HasMany(u => u.ListCart)
                   .WithOne()
                   .HasForeignKey(o => o.IdUser)
                   .HasPrincipalKey(u => u.Id);
            });
         
            modelBuilder.Entity<Voucher>(builder =>
            {
                builder.ToTable("Voucher");
                builder.HasKey(x => x.Id);
                builder.Property(e => e.Id)
               .HasMaxLength(50)
               .IsRequired();
                builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
                builder.Property(x => x.Discount).IsRequired();
                builder.Property(x => x.Expired_Time).IsRequired();
                builder.Property(x => x.isUse).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
