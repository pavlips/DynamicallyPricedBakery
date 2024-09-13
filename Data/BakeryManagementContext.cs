using System;
using System.Collections.Generic;
using DynamicBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicBakery.Data;

public partial class BakeryManagementContext : DbContext
{
    public BakeryManagementContext()
    {
    }

    public BakeryManagementContext(DbContextOptions<BakeryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<PricingLog> PricingLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<SalesTransaction> SalesTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("BakeryDbConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B84338778F");
        });

        modelBuilder.Entity<PricingLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__PricingL__5E5499A8953F4954");

            entity.HasOne(d => d.Product).WithMany(p => p.PricingLogs).HasConstraintName("FK__PricingLo__Produ__440B1D61");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED38BDBD23");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__Promotio__52C42F2F59F36904");

            entity.HasOne(d => d.Product).WithMany(p => p.Promotions).HasConstraintName("FK__Promotion__Produ__46E78A0C");
        });

        modelBuilder.Entity<SalesItem>(entity =>
        {
            entity.HasKey(e => e.SalesItemId).HasName("PK__SalesIte__B97422E1DC04EBB4");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesItems).HasConstraintName("FK__SalesItem__Produ__412EB0B6");

            entity.HasOne(d => d.Transaction).WithMany(p => p.SalesItems).HasConstraintName("FK__SalesItem__Trans__403A8C7D");
        });

        modelBuilder.Entity<SalesTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SalesTra__55433A4B55994306");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesTransactions).HasConstraintName("FK__SalesTran__Custo__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
