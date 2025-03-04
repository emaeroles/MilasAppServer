using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KioscoModel> Kioscos { get; set; }

    public virtual DbSet<ProductModel> Products { get; set; }

    public virtual DbSet<ProductsKioscoModel> ProductsKioscos { get; set; }

    public virtual DbSet<SuppliesProductModel> SuppliesProducts { get; set; }

    public virtual DbSet<SupplyModel> Supplies { get; set; }

    public virtual DbSet<UomModel> Uoms { get; set; }

    public virtual DbSet<UserModel> Users { get; set; }

    public virtual DbSet<VisitModel> Visits { get; set; }

    public virtual DbSet<VisitDetailModel> VisitDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DevelopmentConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KioscoModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("kioscos_pkey");

            entity.ToTable("kioscos");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Dubt)
                .HasColumnType("money")
                .HasColumnName("dubt");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.IsEnableChanges).HasColumnName("is_enable_changes");
            entity.Property(e => e.Manager)
                .HasMaxLength(50)
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(1000)
                .HasColumnName("notes");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");

            entity.HasOne(d => d.User).WithMany(p => p.Kioscos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_kioscos_user-id_fkey");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.CostPrice)
                .HasColumnType("money")
                .HasColumnName("cost_price");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsOwn).HasColumnName("is_own");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.SalePrice)
                .HasColumnType("money")
                .HasColumnName("sale_price");
        });

        modelBuilder.Entity<ProductsKioscoModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_kiosco_pkey");

            entity.ToTable("products_kiosco");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.KioscoId).HasColumnName("kiosco_id");
            entity.Property(e => e.KioscoPrice)
                .HasColumnType("money")
                .HasColumnName("kiosco_price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Kiosco).WithMany(p => p.ProductsKioscos)
                .HasForeignKey(d => d.KioscoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kioscos_products-kiosco_kiosco-id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsKioscos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_products-kiosco_product-id_fkey");
        });

        modelBuilder.Entity<SuppliesProductModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplies_product_pkey");

            entity.ToTable("supplies_product");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            entity.HasOne(d => d.Product).WithMany(p => p.SuppliesProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_supplies-product_product-id_fkey");

            entity.HasOne(d => d.Supply).WithMany(p => p.SuppliesProducts)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplies_supplies-product_supply-id_fkey");
        });

        modelBuilder.Entity<SupplyModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplies_pkey");

            entity.ToTable("supplies");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.CostPrice)
                .HasColumnType("money")
                .HasColumnName("cost_price");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UomId).HasColumnName("uom_id");
            entity.Property(e => e.Yeild).HasColumnName("yeild");

            entity.HasOne(d => d.Uom).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.UomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("uoms_supplies-uom-id_fkey");
        });

        modelBuilder.Entity<UomModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("uoms_pkey");

            entity.ToTable("uoms");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Unit)
                .HasMaxLength(30)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VisitModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visits_pkey");

            entity.ToTable("visits");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.KioscoId).HasColumnName("kiosco_id");

            entity.HasOne(d => d.Kiosco).WithMany(p => p.Visits)
                .HasForeignKey(d => d.KioscoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kioscos_visits_kiosco-id_fkey");
        });

        modelBuilder.Entity<VisitDetailModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_details_pkey");

            entity.ToTable("visit_details");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Changes).HasColumnName("changes");
            entity.Property(e => e.Has).HasColumnName("has");
            entity.Property(e => e.HistSalePrice)
                .HasColumnType("money")
                .HasColumnName("hist_sale_price");
            entity.Property(e => e.Leave).HasColumnName("leave");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Sold).HasColumnName("sold");
            entity.Property(e => e.VisitId).HasColumnName("visit_id");

            entity.HasOne(d => d.Product).WithMany(p => p.VisitDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_visit-details_product-id_fkey");

            entity.HasOne(d => d.Visit).WithMany(p => p.VisitDetails)
                .HasForeignKey(d => d.VisitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visits_visit-details_visit-id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
