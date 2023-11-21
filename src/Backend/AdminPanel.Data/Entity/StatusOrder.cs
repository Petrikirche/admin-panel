using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class StatusOrder
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
