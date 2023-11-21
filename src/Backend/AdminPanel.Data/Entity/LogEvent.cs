using System;
using System.Collections.Generic;

namespace AdminPanel.Data.Entity;

public partial class LogEvent
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
