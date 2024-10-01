using DB_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DB_App.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        private readonly AbiturientContext _context;

        public AdminModel(AbiturientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Faculty Faculty { get; set; }

        [BindProperty]
        public Exam Exam { get; set; }

        [BindProperty]
        public CommitteeMember CommitteeMember { get; set; }

        [BindProperty]
        public Programs Programs { get; set; }

        public string Message { get; private set; }

        public void OnGet()
        {
            // Загрузка необходимых данных
        }

        public async Task<IActionResult> OnPostCreateFacultyAsync(Faculty faculty)
        {
            _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
            Message = "Факультет добавлен успешно!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateExamAsync(Exam exam)
        {
            _context.Exams.AddAsync(exam);
            await _context.SaveChangesAsync();
            Message = "Экзамен добавлен успешно!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateCommitteeMemberAsync(CommitteeMember committeeMember)
        {
            _context.CommitteeMembers.AddAsync(CommitteeMember);
            await _context.SaveChangesAsync();
            Message = "Член комитета добавлен успешно!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCreateProgramsAsync(Programs program)
        {
            _context.Programs.AddAsync(Programs);
            await _context.SaveChangesAsync();
            Message = "Программа добавлена успешно!";
            return RedirectToPage();
        }
    }
}
