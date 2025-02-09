using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClothingCustomization.Data;

public partial class ClothesCusShopContext : DbContext
{
    public ClothesCusShopContext()
    {
    }

    public ClothesCusShopContext(DbContextOptions<ClothesCusShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CustomizeProduct> CustomizeProducts { get; set; }

    public virtual DbSet<DesignArea> DesignAreas { get; set; }

    public virtual DbSet<DesignElement> DesignElements { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStage> OrderStages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-GJ7D6AG\\SQLEXPRESS;Database=ClothesCusShop;Uid=sa12345;Pwd=12345;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__6DB38D4EBC3BE6AF");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.MoTa).HasMaxLength(50);
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<CustomizeProduct>(entity =>
        {
            entity.HasKey(e => e.CustomizeProductId).HasName("PK__Customiz__21B784E8617B64F3");

            entity.ToTable("CustomizeProduct");

            entity.Property(e => e.CustomizeProductId).HasColumnName("CustomizeProduct_ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhToanDien).HasMaxLength(250);
            entity.Property(e => e.MauAo).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(250);
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.CustomizeProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomizeProduct_Product");

            entity.HasOne(d => d.User).WithMany(p => p.CustomizeProducts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomizeProduct_User");
        });

        modelBuilder.Entity<DesignArea>(entity =>
        {
            entity.HasKey(e => e.DesignAreaId).HasName("PK__DesignAr__FA8C6C4CDAD4E605");

            entity.ToTable("DesignArea");

            entity.Property(e => e.DesignAreaId).HasColumnName("DesignArea_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.TenNoiThietKe).HasMaxLength(50);
            entity.Property(e => e.ToaDoX).HasMaxLength(20);
            entity.Property(e => e.ToaDoY).HasMaxLength(20);

            entity.HasOne(d => d.Product).WithMany(p => p.DesignAreas)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesignArea_Product");
        });

        modelBuilder.Entity<DesignElement>(entity =>
        {
            entity.HasKey(e => e.DesignElementId).HasName("PK__DesignEl__4221EE4D9E311C57");

            entity.ToTable("DesignElement");

            entity.Property(e => e.DesignElementId).HasColumnName("DesignElement_ID");
            entity.Property(e => e.CustomizeProductId).HasColumnName("CustomizeProduct_ID");
            entity.Property(e => e.DesignAreaId).HasColumnName("DesignArea_ID");
            entity.Property(e => e.Hinh).HasMaxLength(250);
            entity.Property(e => e.MauKhuVuc).HasMaxLength(20);
            entity.Property(e => e.Size).HasMaxLength(10);
            entity.Property(e => e.Text).HasMaxLength(250);

            entity.HasOne(d => d.CustomizeProduct).WithMany(p => p.DesignElements)
                .HasForeignKey(d => d.CustomizeProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesignElement_CustomizeProduct");

            entity.HasOne(d => d.DesignArea).WithMany(p => p.DesignElements)
                .HasForeignKey(d => d.DesignAreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesignElement_DesignArea");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__CD3992F8698A4564");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("Feedback_ID");
            entity.Property(e => e.DanhGia).HasMaxLength(250);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_Order");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__8C1160B5F12C31BA");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");
            entity.Property(e => e.ChuDe).HasMaxLength(50);
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.TinNhan).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__F1E4639B52D930D4");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.CachVanChuyen).HasMaxLength(50);
            entity.Property(e => e.CustomizeProductId).HasColumnName("CustomizeProduct_ID");
            entity.Property(e => e.DiaChiGiaoHang).HasMaxLength(250);
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.GhiChu).HasMaxLength(250);
            entity.Property(e => e.HoTenNguoiNhan).HasMaxLength(250);
            entity.Property(e => e.NgayDat).HasColumnType("datetime");
            entity.Property(e => e.NgayGiao).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CustomizeProduct).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomizeProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_CustomizeProduct");
        });

        modelBuilder.Entity<OrderStage>(entity =>
        {
            entity.HasKey(e => e.OrderStageId).HasName("PK__OrderSta__B46B8F720C54F989");

            entity.ToTable("OrderStage");

            entity.Property(e => e.OrderStageId).HasColumnName("OrderStage_ID");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.TenTrangThai).HasMaxLength(50);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderStages)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderStage_Order");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__DA6C7FE11EFF56E2");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.DaDatCoc).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.SoTienDatCoc).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TongCong).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__9834FB9A3B5D6CC5");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.TenHangHoa).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB49B182ECB54");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__206D9190AEBA32AF");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hinh).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
