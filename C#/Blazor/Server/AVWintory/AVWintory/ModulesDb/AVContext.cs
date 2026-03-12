using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AVWintory.ModulesDb;

public partial class AVContext : DbContext
{
    public AVContext()
    {
    }

    public AVContext(DbContextOptions<AVContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=AVWintoryDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("Product");

            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.NBillProduct).HasColumnName("n_bill_product");
            entity.Property(e => e.PriceBase).HasColumnName("price_base");
            entity.Property(e => e.PriceSale).HasColumnName("price_sale");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.NBill);

            entity.ToTable("Sale");

            entity.Property(e => e.NBill).HasColumnName("n_bill");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Method).HasColumnName("method");
            entity.Property(e => e.PkSaleDetail).HasColumnName("pk_sale_detail");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.PkSaleDetailNavigation).WithMany(p => p.Sales).HasForeignKey(d => d.PkSaleDetail);
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.IdSaleDetail);

            entity.ToTable("SaleDetail");

            entity.Property(e => e.IdSaleDetail).HasColumnName("id_sale_detail");
            entity.Property(e => e.PkProduct).HasColumnName("pk_product");
            entity.Property(e => e.PriceMoment).HasColumnName("price_moment");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.PkProductNavigation).WithMany(p => p.SaleDetails).HasForeignKey(d => d.PkProduct);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Rol).HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
