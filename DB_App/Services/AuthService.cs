// Services/AuthService.cs
using DB_App.Models;
using DB_App.Services;
using Microsoft.EntityFrameworkCore;


namespace YourNamespace.Services
{
    public class AuthService : IAuthService
    {
        private readonly AbiturientContext _context;

        public AuthService(AbiturientContext context)
        {
            _context = context;
        }

        public async Task<CommitteeMember> Authenticate(string login, string password)
        {
            // Важно: В реальном проекте используйте хэширование паролей!
            return await _context.CommitteeMembers
                .FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }
    }
}
