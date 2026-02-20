namespace EmemIsaac.Blog.Client.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public string Response { get; set; }
    }
}
