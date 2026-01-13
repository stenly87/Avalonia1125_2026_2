using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
}
