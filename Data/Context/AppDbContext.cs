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

    public virtual DbSet<KioscoProductModel> KioscoProducts { get; set; }

    public virtual DbSet<ProductModel> Products { get; set; }

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
            entity.HasKey(e => e.Id).HasName("kioscos_id-pkey");

            entity.ToTable("kioscos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Dubt)
                .HasColumnType("money")
                .HasColumnName("dubt");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
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
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Kioscos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user-kioscos-user_id-fkey");
        });

        modelBuilder.Entity<KioscoProductModel>(entity =>
        {
            entity.HasKey(e => new { e.KioscoId, e.ProductId }).HasName("kiosco_id-product_id-pkey");

            entity.ToTable("kiosco_products");

            entity.Property(e => e.KioscoId).HasColumnName("kiosco_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.KioscoPrice)
                .HasColumnType("money")
                .HasColumnName("kiosco_price");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Kiosco).WithMany(p => p.KioscoProducts)
                .HasForeignKey(d => d.KioscoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kioscos-kiosco_products-kiosco_id-fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.KioscoProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products-kiosco_products-product_id-fkey");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_id-pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
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

            entity.HasMany(d => d.Supplies).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSupply",
                    r => r.HasOne<SupplyModel>().WithMany()
                        .HasForeignKey("SupplyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("supplies-product_supplies-supply_id-fkey"),
                    l => l.HasOne<ProductModel>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("products-product_supplies-product_id-fkey"),
                    j =>
                    {
                        j.HasKey("ProductId", "SupplyId").HasName("product_id-supply_id-pkey");
                        j.ToTable("product_supplies");
                        j.IndexerProperty<Guid>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<Guid>("SupplyId").HasColumnName("supply_id");
                    });
        });

        modelBuilder.Entity<SupplyModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("supplies_id-pkey");

            entity.ToTable("supplies");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
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
                .HasConstraintName("uoms-supplies-uom_id-fkey");
        });

        modelBuilder.Entity<UomModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("uoms_id-pkey");

            entity.ToTable("uoms");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Unit)
                .HasMaxLength(30)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_id-pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
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
            entity.HasKey(e => e.Id).HasName("visits_id-pkey");

            entity.ToTable("visits");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.KioscoId).HasColumnName("kiosco_id");

            entity.HasOne(d => d.Kiosco).WithMany(p => p.Visits)
                .HasForeignKey(d => d.KioscoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kioscos-visits-kiosco_id-fkey");
        });

        modelBuilder.Entity<VisitDetailModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_details_id-pkey");

            entity.ToTable("visit_details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
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
                .HasConstraintName("products-visit_details-product_id-fkey");

            entity.HasOne(d => d.Visit).WithMany(p => p.VisitDetails)
                .HasForeignKey(d => d.VisitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visits-visit_details-visit_id-fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
