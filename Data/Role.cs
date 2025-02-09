﻿using System;
using System.Collections.Generic;

namespace ClothingCustomization.Data;

public partial class Role
{
    public int RoleId { get; set; }

    public string TenVaiTro { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
