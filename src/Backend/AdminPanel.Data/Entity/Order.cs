using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int StatusId { get; set; }

    public DateTime? AnnulateDate { get; set; }

    public int? UserId { get; set; }

    public int Price { get; set; }

    public int? AgentId { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual StatusOrder Status { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User? User { get; set; }
}
