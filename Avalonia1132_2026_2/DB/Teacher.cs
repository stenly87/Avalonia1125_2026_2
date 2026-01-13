using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class Teacher
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
