using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string? ChuDe { get; set; }

    public string? TinNhan { get; set; }

    public DateTime NgayTao { get; set; }

    public bool DaXem { get; set; }

    public virtual User User { get; set; } = null!;
}
