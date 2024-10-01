using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Programs> Programs { get; set; } = new List<Programs>();
}
