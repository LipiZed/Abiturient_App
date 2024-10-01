using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Application
{
    public int Id { get; set; }

    public int ApplicantId { get; set; }

    public int ProgramId { get; set; }

    public DateTime SubmissionDate { get; set; }

    public int StatusId { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Programs Program { get; set; } = null!;

    public virtual ApplicationStatus Status { get; set; } = null!;
}
