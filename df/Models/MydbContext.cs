using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace dairy_farm.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    public virtual DbSet<Сontractor> Сontractors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=karman;database=mydb;allowuservariables=True;useaffectedrows=False", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.46-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("materials");

            entity.HasIndex(e => e.ProductionId, "fk_material_production1_idx");

            entity.HasIndex(e => e.SpecificationId, "fk_material_specification1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BuyPrice).HasColumnName("buyPrice");
            entity.Property(e => e.Code)
                .HasMaxLength(45)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ProductionId).HasColumnName("production_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SellPrice).HasColumnName("sellPrice");
            entity.Property(e => e.SpecificationId).HasColumnName("specification_id");
            entity.Property(e => e.Unit)
                .HasMaxLength(45)
                .HasColumnName("unit");

            entity.HasOne(d => d.Production).WithMany(p => p.Materials)
                .HasForeignKey(d => d.ProductionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_material_production1");

            entity.HasOne(d => d.Specification).WithMany(p => p.Materials)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_material_specification1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Buyer)
                .HasMaxLength(45)
                .HasColumnName("buyer");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Salesman)
                .HasMaxLength(45)
                .HasColumnName("salesman");

            entity.HasMany(d => d.Сontractors).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrdersHasСontractor",
                    r => r.HasOne<Сontractor>().WithMany()
                        .HasForeignKey("СontractorsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_orders_has_сontractors_сontractors1"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_orders_has_сontractors_orders1"),
                    j =>
                    {
                        j.HasKey("OrdersId", "СontractorsId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("orders_has_сontractors");
                        j.HasIndex(new[] { "OrdersId" }, "fk_orders_has_сontractors_orders1_idx");
                        j.HasIndex(new[] { "СontractorsId" }, "fk_orders_has_сontractors_сontractors1_idx");
                        j.IndexerProperty<int>("OrdersId").HasColumnName("orders_id");
                        j.IndexerProperty<int>("СontractorsId").HasColumnName("сontractors_id");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.ProductionId, "fk_product_production1_idx");

            entity.HasIndex(e => e.SpecificationId, "fk_product_specification1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(45)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductionId).HasColumnName("production_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SpecificationId).HasColumnName("specification_id");

            entity.HasOne(d => d.Production).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_production1");

            entity.HasOne(d => d.Specification).WithMany(p => p.Products)
                .HasForeignKey(d => d.SpecificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_specification1");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productions");

            entity.HasIndex(e => e.OrderId, "fk_production_order1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Productions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_production_order1");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("specifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(45)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Сontractor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("сontractors");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Addres)
                .HasMaxLength(45)
                .HasColumnName("addres");
            entity.Property(e => e.Buyer).HasColumnName("buyer");
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Salesman).HasColumnName("salesman");

            entity.HasMany(d => d.Specifications).WithMany(p => p.Сontractors)
                .UsingEntity<Dictionary<string, object>>(
                    "СontractorsHasSpecification",
                    r => r.HasOne<Specification>().WithMany()
                        .HasForeignKey("SpecificationsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_сontractors_has_specifications_specifications1"),
                    l => l.HasOne<Сontractor>().WithMany()
                        .HasForeignKey("СontractorsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_сontractors_has_specifications_сontractors1"),
                    j =>
                    {
                        j.HasKey("СontractorsId", "SpecificationsId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("сontractors_has_specifications");
                        j.HasIndex(new[] { "SpecificationsId" }, "fk_сontractors_has_specifications_specifications1_idx");
                        j.HasIndex(new[] { "СontractorsId" }, "fk_сontractors_has_specifications_сontractors1_idx");
                        j.IndexerProperty<int>("СontractorsId").HasColumnName("сontractors_id");
                        j.IndexerProperty<int>("SpecificationsId").HasColumnName("specifications_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
