using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Barcode { get; set; }

    public int PlaceId { get; set; }

    public int EventId { get; set; }

    public int? OrderId { get; set; }

    public int Price { get; set; }

    public int StatusId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual Order? Order { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual ICollection<ScannedTicket> ScannedTickets { get; set; } = new List<ScannedTicket>();

    public virtual StatusTicket Status { get; set; } = null!;

    public virtual TicketsInCart? TicketsInCart { get; set; }
}
