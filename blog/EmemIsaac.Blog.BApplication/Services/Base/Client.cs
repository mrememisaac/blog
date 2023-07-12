namespace EmemIsaac.Blog.BApplication.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }

    public partial class ServiceClient : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
