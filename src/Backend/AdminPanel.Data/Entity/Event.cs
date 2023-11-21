using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public int ActivityId { get; set; }

    public string? Description { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
