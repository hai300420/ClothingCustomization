using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? TenLoai { get; set; }

    public string? MoTa { get; set; }

    public bool HieuLuc { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
