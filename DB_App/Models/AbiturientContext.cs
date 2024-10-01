using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_App.Models;

public partial class AbiturientContext : DbContext
{
    public AbiturientContext()
    {
    }

    public AbiturientContext(DbContextOptions<AbiturientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<CommitteeMember> CommitteeMembers { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<ExamResult> ExamResults { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Programs> Programs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Abiturient;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applican__3214EC27331AAA3B");

            entity.ToTable("Applicant");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC272F9CC072");

            entity.ToTable("Application");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_Application_Applicant");

            entity.HasOne(d => d.Program).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Program");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Status");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC27B8163DDF");

            entity.ToTable("ApplicationStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<CommitteeMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Committe__3214EC2737C04834");

            entity.ToTable("CommitteeMember");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC27730B210B");

            entity.ToTable("Document");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.DocumentPath).HasMaxLength(255);
            entity.Property(e => e.DocumentType).HasMaxLength(100);
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK_Document_Application");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exam__3214EC277F321D1B");

            entity.ToTable("Exam");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExamDate).HasColumnType("date");
            entity.Property(e => e.ExamName).HasMaxLength(100);
            entity.Property(e => e.ProgramId).HasColumnName("ProgramID");

            entity.HasOne(d => d.Program).WithMany(p => p.Exams)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK_Exam_Program");
        });

        modelBuilder.Entity<ExamResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExamResu__3214EC27E210B02B");

            entity.ToTable("ExamResult");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.ExamId).HasColumnName("ExamID");

            entity.HasOne(d => d.Applicant).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK_ExamResult_Applicant");

            entity.HasOne(d => d.Exam).WithMany(p => p.ExamResults)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK_ExamResult_Exam");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faculty__3214EC277102040B");

            entity.ToTable("Faculty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Log__3214EC27BCCE1406");

            entity.ToTable("Log");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Programs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Program__3214EC27DCA99A84");

            entity.ToTable("Program");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FacultyId).HasColumnName("FacultyID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Programs)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK_Program_Faculty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
