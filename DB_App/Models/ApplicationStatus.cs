using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class ApplicationStatus
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
