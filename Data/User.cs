using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class User
{
    public int UserId { get; set; }

    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string Email { get; set; } = null!;

    public string? Hinh { get; set; }

    public bool HieuLuc { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<CustomizeProduct> CustomizeProducts { get; set; } = new List<CustomizeProduct>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Role Role { get; set; } = null!;
}
