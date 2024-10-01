using DB_App.Models;
using DB_App.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

public class AdminModelTests
{
    [Fact]
    public async Task OnPostCreateFacultyAsync_AddsFacultySuccessfully()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Faculty>>();
        var mockContext = new Mock<AbiturientContext>();

        // Настраиваем метод AddAsync для DbSet
        mockContext.Setup(m => m.Faculties).Returns(mockSet.Object);

        var model = new AdminModel(mockContext.Object)
        {
            Faculty = new Faculty { Name = "Test Faculty" }
        };

        // Act
        var result = await model.OnPostCreateFacultyAsync(model.Faculty);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<Faculty>(), default), Times.Once); // Проверяем, что метод AddAsync был вызван один раз
        Assert.Equal("Факультет добавлен успешно!", model.Message); // Проверяем, что сообщение установлено корректно
        Assert.IsType<RedirectToPageResult>(result); // Проверяем, что возвращается RedirectToPageResult
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once); // Проверяем, что SaveChangesAsync был вызван один раз
    }
    [Fact]
    public async Task OnPostCreateExamAsync_AddsExamSuccessfully()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Exam>>();
        var mockContext = new Mock<AbiturientContext>();

        mockContext.Setup(m => m.Exams).Returns(mockSet.Object);

        var model = new AdminModel(mockContext.Object)
        {
            Exam = new Exam
            {
                ProgramId = 1,
                ExamName = "Test Exam",
                ExamDate = DateTime.Now,
                MaxScore = 100
            }
        };

        // Act
        var result = await model.OnPostCreateExamAsync(model.Exam);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<Exam>(), default), Times.Once);
        Assert.Equal("Экзамен добавлен успешно!", model.Message);
        Assert.IsType<RedirectToPageResult>(result);
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
    }

    // Тест для метода OnPostCreateCommitteeMemberAsync
    [Fact]
    public async Task OnPostCreateCommitteeMemberAsync_AddsCommitteeMemberSuccessfully()
    {
        // Arrange
        var mockSet = new Mock<DbSet<CommitteeMember>>();
        var mockContext = new Mock<AbiturientContext>();

        mockContext.Setup(m => m.CommitteeMembers).Returns(mockSet.Object);

        var model = new AdminModel(mockContext.Object)
        {
            CommitteeMember = new CommitteeMember
            {
                Login = "testuser",
                Password = "password",
                Role = "Member"
            }
        };

        // Act
        var result = await model.OnPostCreateCommitteeMemberAsync(model.CommitteeMember);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<CommitteeMember>(), default), Times.Once);
        Assert.Equal("Член комитета добавлен успешно!", model.Message);
        Assert.IsType<RedirectToPageResult>(result);
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
    }

    // Тест для метода OnPostCreateProgramsAsync
    [Fact]
    public async Task OnPostCreateProgramsAsync_AddsProgramSuccessfully()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Programs>>();
        var mockContext = new Mock<AbiturientContext>();

        mockContext.Setup(m => m.Programs).Returns(mockSet.Object);

        var model = new AdminModel(mockContext.Object)
        {
            Programs = new Programs
            {
                Name = "Test Program",
                FacultyId = 1,
                Description = "Program Description",
                DurationYears = 4
            }
        };

        // Act
        var result = await model.OnPostCreateProgramsAsync(model.Programs);

        // Assert
        mockSet.Verify(m => m.AddAsync(It.IsAny<Programs>(), default), Times.Once);
        Assert.Equal("Программа добавлена успешно!", model.Message);
        Assert.IsType<RedirectToPageResult>(result);
        mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
    }
}
