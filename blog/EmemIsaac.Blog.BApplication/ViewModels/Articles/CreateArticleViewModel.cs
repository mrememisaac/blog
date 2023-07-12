using System.ComponentModel.DataAnnotations;

namespace EmemIsaac.Blog.BApplication.ViewModels.Articles
{
    public class CreateArticleViewModel
    {
        public const int MinimumTitleLength = 10;
        public const int MinimumDescriptionLength = 20;
        public const int MinimumContentLength = 150;
        public const int MaximumTitleLength = MinimumTitleLength * 10;
        public const int MaximumDescriptionLength = MinimumDescriptionLength * 10;
        public const int ImageUrlMaximumLength = 250;
        public const int ContextMaximumLength = 4000;

        [Required]
        [StringLength(MaximumTitleLength, ErrorMessage = "Title should be {0} characters or less")]
        [MinLength(MinimumTitleLength, ErrorMessage = "Title should be {0} characters or more")]
        public string Title { get; set; }

        [Required]
        [StringLength(ImageUrlMaximumLength, ErrorMessage = "The name of the event should be {0} characters or less")]
        public string ImageUrl { get; set; }

        public string Url { get { return Title.Replace(" ","-");  } }

        [Required]
        [StringLength(MaximumDescriptionLength, ErrorMessage = "Description should be {0} characters or less")]
        [MinLength(MinimumDescriptionLength, ErrorMessage = "Description should be {0} characters or more")] 
        public string Description { get; set; }

        [Required]
        [StringLength(ContextMaximumLength, ErrorMessage = "Description should be {0} characters or less")]
        public string Content { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

    }
}
