using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class BookingRequest
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int StudentsCount { get; set; }

    public string Status { get; set; } = null!;

    public string? AdminComment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int TeacherId { get; set; }

    public int ClassroomId { get; set; }

    public virtual Classroom Classroom { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
