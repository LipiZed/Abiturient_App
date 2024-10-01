using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Programs
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FacultyId { get; set; }

    public string? Description { get; set; }

    public int DurationYears { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual Faculty Faculty { get; set; } = null!;
}
