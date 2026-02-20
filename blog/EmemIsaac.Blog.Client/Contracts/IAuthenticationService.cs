using System.Threading;

namespace EmemIsaac.Blog.Client.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password, CancellationToken cancellationToken);

        Task<bool> Register(string firstName, string lastName, string userName, string email, string password, CancellationToken cancellationToken);

        Task Logout(CancellationToken cancellationToken);
    }
}
