using EmemIsaac.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EmemIsaac.Blog.Domain.Entities
{

    public class Article : Entity
    {
        public const int MinimumTitleLength = 10;
        public const int MinimumDescriptionLength = 20;
        public const int MaximumTitleLength = MinimumTitleLength * 10;
        public const int MaximumDescriptionLength = MinimumDescriptionLength * 10;

        [SetsRequiredMembers]
        public Article(Guid id, string title, string imageUrl, string url, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or empty.", nameof(title));
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentException($"'{nameof(imageUrl)}' cannot be null or empty.", nameof(imageUrl));
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException($"'{nameof(url)}' cannot be null or empty.", nameof(url));
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException($"'{nameof(description)}' cannot be null or empty.", nameof(description));
            }
            Id = id;
            Title = title;
            ImageUrl = imageUrl;
            Url = url;
            Description = description;
        }

        private Article() { }

        public required string Title { get; init; }

        public required string ImageUrl { get; init; }

        public required string Url { get; init; }

        public required string Description { get; init; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public Stage Stage { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
