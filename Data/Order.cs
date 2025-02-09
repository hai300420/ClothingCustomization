using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomizeProductId { get; set; }

    public DateTime? NgayDat { get; set; }

    public DateTime? NgayGiao { get; set; }

    public string? HoTenNguoiNhan { get; set; }

    public string? DiaChiGiaoHang { get; set; }

    public string? CachVanChuyen { get; set; }

    public double? PhiVanChuyen { get; set; }

    public string? GhiChu { get; set; }

    public decimal? DonGia { get; set; }

    public int? SoLuong { get; set; }

    public decimal? TongTien { get; set; }

    public virtual CustomizeProduct CustomizeProduct { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderStage> OrderStages { get; set; } = new List<OrderStage>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
