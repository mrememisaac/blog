﻿using EmemIsaac.Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmemIsaac.Blog.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired()
                .HasMaxLength(Category.MaximumCategoryNameLength);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.CreatorId).IsRequired();
            builder.Property(p => p.Url).IsRequired().HasMaxLength(Category.MaximumCategoryNameLength);
            builder.Property(p => p.CreatorId).IsRequired().HasMaxLength(Article.MaximumUserIdLength);
            builder.Property(p => p.ModifierId).HasMaxLength(Article.MaximumUserIdLength);
        }
    }
}
