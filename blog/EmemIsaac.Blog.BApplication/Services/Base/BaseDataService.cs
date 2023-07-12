using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using EmemIsaac.Blog.BApplication;

namespace EmemIsaac.Blog.BApplication.Services.Base
{
    public class BaseDataService
    {
        protected readonly ILocalStorageService _localStorageService;

        protected IClient _client;

        public BaseDataService(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new ApiResponse<Guid>() { Message = ex.Message, Success = false };
            }
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorageService.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("token"));
        }
    }
}
