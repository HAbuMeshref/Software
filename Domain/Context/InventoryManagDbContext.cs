using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.Extensions.Hosting;

namespace Domain.Context;

public partial class InventoryManagDbContext : DbContext
{
  // Scaffold-DbContext "Data Source=C:\Users\h.abumeshref\source\repos\Inventory Management\Happy Company.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -Context ApplicationDbContext -ContextDir Data -Force
    private readonly IHostEnvironment _environment;

    public InventoryManagDbContext()
    {
    }

    public InventoryManagDbContext(DbContextOptions<InventoryManagDbContext> options, IHostEnvironment hostEnvironment)
        : base(options)
    {
        _environment = hostEnvironment;
    }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<LookupDetail> LookupDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

        if (_environment.IsDevelopment())
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\h.abumeshref\\source\\repos\\Inventory Management\\Happy Company.db");
        }
        else
        {
            optionsBuilder.UseSqlite(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
        }

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.ToTable("Lookup");

            entity.HasIndex(e => e.Code, "IX_Lookup_CODE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.CreationUser).HasColumnName("CREATION_USER");
            entity.Property(e => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
            entity.Property(e => e.ModificationUser).HasColumnName("MODIFICATION_USER");
            entity.Property(e => e.Name).HasColumnName("NAME");
        });

        modelBuilder.Entity<LookupDetail>(entity =>
        {
            entity.ToTable("Lookup_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.CreationUser).HasColumnName("CREATION_USER");
            entity.Property(e => e.DestinationName)
                .HasColumnType("INTEGER")
                .HasColumnName("DESTINATION_NAME");
            entity.Property(e => e.DestinationValue).HasColumnName("DESTINATION_VALUE");
            entity.Property(e => e.LookupCode).HasColumnName("LOOKUP_CODE");
            entity.Property(e => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
            entity.Property(e => e.ModificationUser).HasColumnName("MODIFICATION_USER");
            entity.Property(e => e.SourceName).HasColumnName("SOURCE_NAME");

            //entity.HasOne(d => d.LookupCodeNavigation).WithMany(p => p.LookupDetails)
            //    .HasPrincipalKey(p => p.Code)
            //    .HasForeignKey(d => d.LookupCode)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_EMAIL").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.ConfirmPassword).HasColumnName("CONFIRM_PASSWORD");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.CreationUser).HasColumnName("CREATION_USER");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
            entity.Property(e => e.ModificationUser).HasColumnName("MODIFICATION_USER");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Role).HasColumnName("ROLE");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.ToTable("Warehouse");

            entity.HasIndex(e => e.Name, "IX_Warehouse_NAME").IsUnique();

            entity.Property(e => e.Address).HasColumnName("ADDRESS");
            entity.Property(e => e.City).HasColumnName("CITY");
            entity.Property(e => e.CountryCode).HasColumnName("COUNTRY_CODE");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.CreationUser).HasColumnName("CREATION_USER ");
            entity.Property(e => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
            entity.Property(e => e.ModificationUser).HasColumnName("MODIFICATION_USER");
            entity.Property(e => e.Name).HasColumnName("NAME");
        });

        modelBuilder.Entity<WarehouseItem>(entity =>
        {
            entity.ToTable("Warehouse_Items");

            entity.HasIndex(e => e.Name, "IX_Warehouse_Items_NAME").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostPrice).HasColumnName("COST_PRICE");
            entity.Property(e => e.CreationDate).HasColumnName("CREATION_DATE");
            entity.Property(e => e.CreationUser).HasColumnName("CREATION_USER");
            entity.Property(e => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
            entity.Property(e => e.ModificationUser).HasColumnName("MODIFICATION_USER");
            entity.Property(e => e.MsrpPrice).HasColumnName("MSRP_PRICE");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.SkuCode).HasColumnName("SKU_CODE");
            entity.Property(e => e.WarehouseId).HasColumnName("WAREHOUSE_ID");

            //entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseItems)
            //    .HasForeignKey(d => d.WarehouseId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
