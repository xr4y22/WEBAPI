using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models;

public partial class SanataContext : DbContext
{
    public SanataContext()
    {
    }

    public SanataContext(DbContextOptions<SanataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MItem> MItems { get; set; }

    public virtual DbSet<MItemLocation> MItemLocations { get; set; }

    public virtual DbSet<MLocation> MLocations { get; set; }

    public virtual DbSet<MSupplier> MSuppliers { get; set; }

    public virtual DbSet<MSupplierItem> MSupplierItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SanataDatabase"));
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-AJM2LEC\\SQLEXPRESS;Database=Sanata;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MItem>(entity =>
        {
            entity.ToTable("mItem");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SellingPrice).HasColumnType("money");
        });

        modelBuilder.Entity<MItemLocation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mItemLocation");

            entity.HasOne(d => d.IdItemNavigation).WithMany()
                .HasForeignKey(d => d.IdItem)
                .HasConstraintName("FK_mItemLocation_mItem");

            entity.HasOne(d => d.IdLocationNavigation).WithMany()
                .HasForeignKey(d => d.IdLocation)
                .HasConstraintName("FK_mItemLocation_mLocation");
        });

        modelBuilder.Entity<MLocation>(entity =>
        {
            entity.ToTable("mLocation");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MSupplier>(entity =>
        {
            entity.ToTable("mSupplier");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MSupplierItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("mSupplierItem");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdItemNavigation).WithMany()
                .HasForeignKey(d => d.IdItem)
                .HasConstraintName("FK_mSupplierItem_mItem");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany()
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("FK_mSupplierItem_mSupplier");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
