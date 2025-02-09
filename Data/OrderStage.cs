using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class OrderStage
{
    public int OrderStageId { get; set; }

    public int OrderId { get; set; }

    public string TenTrangThai { get; set; } = null!;

    public DateTime? NgayCapNhat { get; set; }

    public virtual Order Order { get; set; } = null!;
}
