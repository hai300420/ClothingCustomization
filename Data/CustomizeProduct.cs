using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class CustomizeProduct
{
    public int CustomizeProductId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public string? MauAo { get; set; }

    public string? HinhToanDien { get; set; }

    public string? MoTa { get; set; }

    public decimal DonGia { get; set; }

    public virtual ICollection<DesignElement> DesignElements { get; set; } = new List<DesignElement>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
