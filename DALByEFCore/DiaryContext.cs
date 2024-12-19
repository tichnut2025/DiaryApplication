using System;
using System.Collections.Generic;
using DBEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace DBEntities;

public partial class DiaryContext : DbContext
{
    public DiaryContext()
    {
    }

    public DiaryContext(DbContextOptions<DiaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeSalaryTbl> EmployeeSalaryTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<ProductsTbl> ProductsTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\MiriShim\\Documents\\StoreDBForZuker.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK_Customer_tbl");

            entity.HasIndex(e => e.EmpId, "IX_Customers_EmpID");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustCity)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustFax)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");

            entity.HasOne(d => d.Emp).WithMany(p => p.Customers)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_Customer_tbl_Employee_tbl");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK_Employee_tbl");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Emptz)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ManagerId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("managerID");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<EmployeeSalaryTbl>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.PeriodDate });

            entity.ToTable("EmployeeSalary_tbl");

            entity.Property(e => e.EmpId).HasColumnName("EmpID");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeSalaryTbls)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalary_tbl_Employee_tbl");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.Ordnum);

            entity.ToTable("Orders_tbl");

            entity.HasIndex(e => e.CustId, "IX_Orders_tbl_CustID");

            entity.HasIndex(e => e.ProdId, "IX_Orders_tbl_ProdID");

            entity.Property(e => e.CustId).HasColumnName("CustID");
            entity.Property(e => e.Orddate).HasColumnName("orddate");
            entity.Property(e => e.ProdId).HasColumnName("ProdID");

            entity.HasOne(d => d.Cust).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK_Orders_tbl_Customer_tbl");

            entity.HasOne(d => d.Prod).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.ProdId)
                .HasConstraintName("FK_Orders_tbl_Products_tbl");
        });

        modelBuilder.Entity<ProductsTbl>(entity =>
        {
            entity.HasKey(e => e.ProdId);

            entity.ToTable("Products_tbl");

            entity.Property(e => e.ProdId).HasColumnName("ProdID");
            entity.Property(e => e.CostBuy).HasColumnName("cost_buy");
            entity.Property(e => e.CostSale).HasColumnName("Cost_sale");
            entity.Property(e => e.ProdDesc)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QtyStock).HasColumnName("qty_stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
