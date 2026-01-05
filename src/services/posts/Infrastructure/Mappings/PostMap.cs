using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsApi.Domain.Entities;

namespace PostsApi.Infrastructure.Mappings;

class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(e => e.Id);
        builder.ToTable(nameof(Post));
        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.AuthorId).IsRequired();
        builder.Property(e => e.Description).IsRequired().HasMaxLength(Post.MaxDescriptionLength);
        builder.Property(e => e.LikesCount).IsRequired().HasDefaultValue(0);
        builder.Property(e => e.CommentsCount).IsRequired().HasDefaultValue(0);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired(false);
    }
}