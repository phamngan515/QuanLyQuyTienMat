using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class QuanLyTienMatContext : DbContext
{
    public QuanLyTienMatContext()
    {
    }

    public QuanLyTienMatContext(DbContextOptions<QuanLyTienMatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GiaoDich> GiaoDiches { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=QuanLyTienMat;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GiaoDich>(entity =>
        {
            entity.HasKey(e => e.GiaoDichId).HasName("PK__GiaoDich__D8D14B310C589D28");

            entity.ToTable("GiaoDich");

            entity.HasIndex(e => e.SoCt, "UQ__GiaoDich__BC3D1CA82009D386").IsUnique();

            entity.Property(e => e.GiaoDichId).HasColumnName("GiaoDichID");
            entity.Property(e => e.ChungTuGoc).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.NgayCt)
                .HasColumnType("datetime")
                .HasColumnName("NgayCT");
            entity.Property(e => e.SoCt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SoCT");
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SoTienBangChu).HasMaxLength(255);
            entity.Property(e => e.TenDoiTuong).HasMaxLength(200);
            entity.Property(e => e.TkdoiUng)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TKDoiUng");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.NguoiDungId).HasName("PK__NguoiDun__C4BBA4DD1C097B1D");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.TenNguoiDung, "UQ__NguoiDun__57E5A81D1AA6E4BB").IsUnique();

            entity.Property(e => e.NguoiDungId).HasColumnName("NguoiDungID");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenNguoiDung)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VaiTroId).HasColumnName("VaiTroID");

            entity.HasOne(d => d.VaiTro).WithMany(p => p.NguoiDungs)
                .HasForeignKey(d => d.VaiTroId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.VaiTroId).HasName("PK__VaiTro__477581362A1144F7");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVaiTro, "UQ__VaiTro__1DA558144CD9EAE8").IsUnique();

            entity.Property(e => e.VaiTroId).HasColumnName("VaiTroID");
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });
        // 1. Dữ liệu VaiTro
        modelBuilder.Entity<VaiTro>().HasData(
            new { VaiTroId = 1, TenVaiTro = "Admin" },
            new { VaiTroId = 2, TenVaiTro = "Kế toán" }
        );

        // 2. Dữ liệu NguoiDung (Pass: 123)
        modelBuilder.Entity<NguoiDung>().HasData(
            new
            {
                NguoiDungId = 1,
                TenNguoiDung = "admin",
                MatKhau = "202CB962AC59075B964B07152D234B70",
                VaiTroId = 1
            }
        );

        // 3. Dữ liệu GiaoDich mẫu
        modelBuilder.Entity<GiaoDich>().HasData(
            new
            {
                GiaoDichId = 1,
                SoCt = "PT001",
                NgayCt = new DateTime(2026, 3, 1),
                SoTien = 10000000m,
                TenDoiTuong = "Công ty ABC"
                // Lưu ý: Các trường nullable không cần điền ở đây
            },
            new
            {
                GiaoDichId = 2,
                SoCt = "PC001",
                NgayCt = new DateTime(2026, 3, 5),
                SoTien = 2500000m,
                TenDoiTuong = "Điện lực Hà Nội"
            }
        );
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
