using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using AutoMapper;
using EmemIsaac.Blog.Client.ViewModels.Articles;
using EmemIsaac.Blog.Client.Exceptions;
using EmemIsaac.Blog.Client.Services.Base;

namespace EmemIsaac.Blog.Client.Services.Base
{
    public class BaseDataService
    {
        protected IMapper _mapper;
        protected HttpClient _client;
        protected readonly ILocalStorageService _localStorageService;
        protected string _serviceAddress;
        protected JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public BaseDataService(HttpClient client, ILocalStorageService localStorageService, IMapper mapper)
        {
            _client = client;
            _localStorageService = localStorageService;
            _mapper = mapper;
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
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("token"));
        }

        public async Task<ApiResponse<TOutput>> PostAsync<TInput, TOutput>(TInput input)
        {
            if (input == null) throw new ArgumentNullException($"{nameof(input)} cannot be null");
            if (_mapper == null) throw new ArgumentNullException($"{nameof(_mapper)} cannot be null");
            if (_serviceAddress == null) throw new ArgumentNullException($"{nameof(_serviceAddress)} cannot be null");

            await AddBearerToken();
            try
            {
                //var payload = new StringContent(JsonSerializer.Serialize(_mapper.Map<TCommand>(input)));
                var payload = new StringContent(JsonSerializer.Serialize(input, _jsonSerializerOptions));
                var response = await _client.PostAsync(_serviceAddress, payload);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<TOutput>(responseString, _jsonSerializerOptions);
                return new ApiResponse<TOutput> { Success = true, Data = data };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<TOutput>(ex);
            }
        }

        public async Task<ApiResponse<TOutput>> PutAsync<TInput, TOutput>(TInput input)
        {
            if (input == null) throw new ArgumentNullException($"{nameof(input)} cannot be null");
            if (_mapper == null) throw new ArgumentNullException($"{nameof(_mapper)} cannot be null");
            if (_serviceAddress == null) throw new ArgumentNullException($"{nameof(_serviceAddress)} cannot be null");

            await AddBearerToken();
            try
            {
                //var payload = new StringContent(JsonSerializer.Serialize(_mapper.Map<TCommand>(input)));
                var payload = new StringContent(JsonSerializer.Serialize(input, _jsonSerializerOptions));
                var response = await _client.PutAsync(_serviceAddress, payload);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<TOutput>(responseString, _jsonSerializerOptions);
                return new ApiResponse<TOutput> { Success = true, Data = data };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<TOutput>(ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            await AddBearerToken();
            await _client.DeleteAsync($"{_serviceAddress}/{id}");
        }


        public async Task<ApiResponse<IEnumerable<TOutput>>> GetAll<TOutput>()
        {            
            await AddBearerToken();
            var responseStream = await _client.GetStreamAsync(_serviceAddress);
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<TOutput>>(responseStream, _jsonSerializerOptions);
            return new ApiResponse<IEnumerable<TOutput>> { Data = data, Success = true };
        }

        public async Task<ApiResponse<TOutput>> GetByIdOrUrl<TInput, TOutput>(TInput input)
        {
            await AddBearerToken();
            var responseStream = await _client.GetStreamAsync($"{_serviceAddress}/{input}");
            var data = await JsonSerializer.DeserializeAsync<TOutput>(responseStream, _jsonSerializerOptions);
            return new ApiResponse<TOutput> { Data = data, Success = true };
        }
    }
}
