using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class CommitteeMember
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
}
