using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string Login { get; set; } = null!;

    public string Passwords { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Commentary { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<ScannedTicket> ScannedTickets { get; set; } = new List<ScannedTicket>();
}
