using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class Admin
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Login { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
