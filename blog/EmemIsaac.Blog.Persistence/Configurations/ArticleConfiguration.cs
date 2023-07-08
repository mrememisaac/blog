using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmemIsaac.Blog.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(p => p.Url).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(Article.MaximumTitleLength);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(Article.UrlMaximumLength);
            builder.Property(p => p.Content).IsRequired().HasMaxLength(Article.ContextMaximumLength);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(Article.MaximumDescriptionLength);
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(Article.ImageUrlMaximumLength);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.CreatorId).IsRequired().HasMaxLength(Article.MaximumUserIdLength);
            builder.Property(p => p.ModifierId).HasMaxLength(Article.MaximumUserIdLength);
        }
    }
}
