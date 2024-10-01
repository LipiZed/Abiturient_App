using DB_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DB_App.Pages
{
    [Authorize(Roles = "Admin,Editor,Watcher")]
    public class WatcherModel : PageModel
    {
        private readonly AbiturientContext _context;

        public WatcherModel(AbiturientContext context)
        {
            _context = context;
        }

        public List<Application> Applications { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Applications = await _context.Applications
                .Include(a => a.Applicant)
                .Include(a => a.Status)
                .ToListAsync();

            return Page();
        }
    }
}
