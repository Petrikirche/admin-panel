using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class StatusTicket
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
