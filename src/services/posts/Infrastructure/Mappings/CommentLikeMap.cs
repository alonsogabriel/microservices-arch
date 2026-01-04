using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsApi.Domain.Entities;

namespace PostsApi.Infrastructure.Mappings;

class CommentLikeMap : IEntityTypeConfiguration<CommentLike>
{
    public void Configure(EntityTypeBuilder<CommentLike> builder)
    {
        builder.HasKey(e => new { e.CommentId, e.UserId });
        builder.ToTable(nameof(CommentLike));
        builder.HasOne<Comment>().WithMany().HasForeignKey(e => e.CommentId).IsRequired();
        builder.Property(e => e.CreatedAt).IsRequired();
    }
}