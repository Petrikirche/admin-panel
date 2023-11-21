using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class TicketsInCart
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public string CartIdentify { get; set; } = null!;

    public DateTime AnnulateDate { get; set; }

    public virtual Cart CartIdentifyNavigation { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
