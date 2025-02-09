using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string? TenHangHoa { get; set; }

    public decimal? DonGia { get; set; }

    public int HangTonKho { get; set; }

    public string? Hinh { get; set; }

    public string? MoTa { get; set; }

    public bool HieuLuc { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CustomizeProduct> CustomizeProducts { get; set; } = new List<CustomizeProduct>();

    public virtual ICollection<DesignArea> DesignAreas { get; set; } = new List<DesignArea>();
}
