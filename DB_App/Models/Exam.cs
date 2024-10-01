using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Exam
{
    public int Id { get; set; }

    public int ProgramId { get; set; }

    public string ExamName { get; set; } = null!;

    public DateTime ExamDate { get; set; }

    public int MaxScore { get; set; }

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();

    public virtual Programs Program { get; set; } = null!;
}
