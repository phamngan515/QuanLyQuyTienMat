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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
