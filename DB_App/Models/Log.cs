using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Log
{
    public int Id { get; set; }

    public string TableName { get; set; } = null!;

    public string Action { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime? Timestamp { get; set; }
}
