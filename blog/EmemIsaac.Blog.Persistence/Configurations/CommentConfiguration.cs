using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmemIsaac.Blog.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(p => p.AuthorName).IsRequired().HasMaxLength(Comment.MaximumUserIdLength);
            builder.Property(p => p.Content).IsRequired().HasMaxLength(Comment.ContentMaximumLength);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.CreatorId).IsRequired().HasMaxLength(Article.MaximumUserIdLength);
            builder.Property(p => p.ModifierId).HasMaxLength(Article.MaximumUserIdLength);

        }
    }
}
