using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Document
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string DocumentType { get; set; } = null!;

    public string DocumentPath { get; set; } = null!;

    public DateTime? UploadDate { get; set; }

    public virtual Application Application { get; set; } = null!;
}
