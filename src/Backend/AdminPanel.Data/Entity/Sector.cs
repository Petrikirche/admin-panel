using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class Sector
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
