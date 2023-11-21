using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Log
{
    public long Id { get; set; }

    public int? UserId { get; set; }

    public int LogEventId { get; set; }

    public int? TicketId { get; set; }

    public int? OrderId { get; set; }

    public int? EventId { get; set; }

    public string? Description { get; set; }

    public DateTime LogDate { get; set; }

    public virtual Event? Event { get; set; }

    public virtual LogEvent LogEvent { get; set; } = null!;

    public virtual Order? Order { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
