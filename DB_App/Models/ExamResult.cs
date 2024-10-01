using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class ExamResult
{
    public int Id { get; set; }

    public int ApplicantId { get; set; }

    public int ExamId { get; set; }

    public int Score { get; set; }

    public virtual Applicant Applicant { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;
}
