using System;

namespace Avalonia1132_2026_2.VM;

public class User
{
    public string Name { get; set; } = "Укажите имя";
    public DateTime Birthday { get; set; } = DateTime.Today;
    public double LazyLevel  { get; set; }
}