using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsApi.Domain.Entities;

namespace PostsApi.Infrastructure.Mappings;

class PostLikeMap : IEntityTypeConfiguration<PostLike>
{
    public void Configure(EntityTypeBuilder<PostLike> builder)
    {
        builder.HasKey(e => new { e.PostId, e.UserId });
        builder.ToTable(nameof(PostLike));
        builder.HasOne<Post>().WithMany().HasForeignKey(e => e.PostId).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
    }
}