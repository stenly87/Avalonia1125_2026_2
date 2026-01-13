using System;
using System.Collections.Generic;

namespace Avalonia1132_2026_2.DB;

public partial class Classroom
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Building { get; set; } = null!;

    public int Capacity { get; set; }

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();
}
