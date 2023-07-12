using EmemIsaac.Blog.Application.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EmemIsaac.Blog.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoggedInUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string UserId
        {
            get
            {
                return "Emem Isaac";
                return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
