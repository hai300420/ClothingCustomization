using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int SoSao { get; set; }

    public string DanhGia { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
