namespace EmemIsaac.Blog.Shared.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public string Response { get; set; }
    }
}
