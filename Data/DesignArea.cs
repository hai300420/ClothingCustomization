using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class DesignArea
{
    public int DesignAreaId { get; set; }

    public int ProductId { get; set; }

    public string? TenNoiThietKe { get; set; }

    public string? ToaDoX { get; set; }

    public string? ToaDoY { get; set; }

    public virtual ICollection<DesignElement> DesignElements { get; set; } = new List<DesignElement>();

    public virtual Product Product { get; set; } = null!;
}
