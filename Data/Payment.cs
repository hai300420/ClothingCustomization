using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public decimal? TongCong { get; set; }

    public decimal? DaDatCoc { get; set; }

    public decimal? SoTienDatCoc { get; set; }

    public DateTime? NgayThanhToan { get; set; }

    public virtual Order Order { get; set; } = null!;
}
