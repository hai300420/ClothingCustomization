using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class DesignElement
{
    public int DesignElementId { get; set; }

    public int DesignAreaId { get; set; }

    public int CustomizeProductId { get; set; }

    public string? Hinh { get; set; }

    public string? Text { get; set; }

    public string? Size { get; set; }

    public string? MauKhuVuc { get; set; }

    public virtual CustomizeProduct CustomizeProduct { get; set; } = null!;

    public virtual DesignArea DesignArea { get; set; } = null!;
}
