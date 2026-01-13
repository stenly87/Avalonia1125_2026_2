using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class Schedule
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string Discipline { get; set; } = null!;

    public int ClassroomId { get; set; }

    public int TeacherId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
