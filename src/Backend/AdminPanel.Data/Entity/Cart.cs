using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Cart
{
    public string Identify { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<TicketsInCart> TicketsInCarts { get; set; } = new List<TicketsInCart>();

    public virtual User User { get; set; } = null!;
}
