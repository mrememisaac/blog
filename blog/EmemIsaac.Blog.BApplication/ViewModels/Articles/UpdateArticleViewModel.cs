namespace EmemIsaac.Blog.BApplication.ViewModels.Articles
{
    public class UpdateArticleViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

    }
}
