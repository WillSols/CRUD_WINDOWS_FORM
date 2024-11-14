using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CRUD_WINDOWS_FORM_TESTE.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
    {
    }

    public virtual DbSet<Clients> Clients { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    // Abstração, caso necessário mudança de conectivos acessar a App.config
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["DbApp"].ConnectionString;
        optionsBuilder.UseNpgsql(connectionString);
    }

    //Configuração dos modelos para com o banco de dados
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clients>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");
            entity.ToTable("clients");
            entity.HasIndex(e => e.Email, "clientes_email_key").IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(255).HasColumnName("address");
            entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("email");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pkey");
            entity.ToTable("products");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Price).HasPrecision(10, 2).HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("sales_pkey");
            entity.ToTable("sales");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.UnitPrice).HasPrecision(10, 2).HasColumnName("unit_price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.SaleDate).HasColumnName("sale_date");
            entity.HasOne(d => d.Client).WithMany(p => p.Sales).HasForeignKey(d => d.ClientId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("sales_client_id_fkey");
            entity.HasOne(d => d.Product).WithMany(p => p.Sales).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("sales_product_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
