using System;
using System.Collections.Generic;

namespace DB_App.Models;

public partial class Applicant
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<ExamResult> ExamResults { get; set; } = new List<ExamResult>();
}
