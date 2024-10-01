using DB_App.Models;

namespace DB_App.Services
{
    public interface IAuthService
    {
        Task<CommitteeMember> Authenticate(string login, string password);
    }
}
