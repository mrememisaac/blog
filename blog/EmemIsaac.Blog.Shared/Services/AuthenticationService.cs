using AutoMapper;
using Blazored.LocalStorage;
using EmemIsaac.Blog.Shared.Auth;
using EmemIsaac.Blog.Shared.Contracts;
using EmemIsaac.Blog.BApplication.Services.Base;
using EmemIsaac.Blog.Shared.Features.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace EmemIsaac.Blog.Shared.Services
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider, IMapper mapper) : 
            base(client, localStorage, mapper)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _serviceAddress = "api/authentication";
        }

        public async Task<bool> Authenticate(string email, string password, CancellationToken cancellationToken)
        {
            
            try
            {
                var authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
                var response = await PostAsync<AuthenticationRequest, AuthenticationResponse>(authenticationRequest);
                if (response?.Data?.Token != string.Empty)
                {
                    await _localStorageService.SetItemAsync("token", response?.Data?.Token);
                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response?.Data?.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout(CancellationToken cancellationToken)
        {
            await _localStorageService.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password, CancellationToken cancellationToken)
        {
            var registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await PostAsync<RegistrationRequest, RegistrationResponse>(registrationRequest);
            if (!string.IsNullOrEmpty(response?.Data?.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
