using DB_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DB_App.Pages
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorModel : PageModel
    {
        private readonly AbiturientContext _context;

        public EditorModel(AbiturientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Applicant Applicant { get; set; }

        [BindProperty]
        public Application Application { get; set; }

        [BindProperty]
        public Document Document { get; set; }

        [BindProperty]
        public ExamResult ExamResult { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostCreateFullEntryAsync(
        Applicant applicant,
        Application application,
        Document document,
        ExamResult examResult)
        {
            // ���������� ������ ���������
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();

            // ���������� ID ��������� ��� ������ � ��������
            application.ApplicantId = applicant.Id;
            examResult.ApplicantId = applicant.Id;

            // ���������� ������ ������
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            // ���������� ID ������ ��� ���������
            document.ApplicationId = application.Id;

            // ���������� ������ ���������
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            // ���������� ������ ����������� ��������
            _context.ExamResults.Add(examResult);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }


    }
}
