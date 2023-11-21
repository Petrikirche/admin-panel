using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class ScannedTicket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? TicketId { get; set; }

    public DateTime Dates { get; set; }

    public int StatusId { get; set; }

    public string? WrongTicketBarcode { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User User { get; set; } = null!;
}
