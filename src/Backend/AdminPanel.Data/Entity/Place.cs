using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Place
{
    public int Id { get; set; }

    public string Row { get; set; } = null!;

    public string Place1 { get; set; } = null!;

    public int X { get; set; }

    public int Y { get; set; }

    public int SectorId { get; set; }

    public virtual Sector Sector { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
