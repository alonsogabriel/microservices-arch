using Microsoft.EntityFrameworkCore;
using PostsApi.Domain.Entities;
using PostsApi.Infrastructure.Mappings;

namespace PostsApi.Infrastructure;

class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; init; }
    public DbSet<Comment> Comments { get; init; }
    public DbSet<PostLike> PostLikes { get; init; }
    public DbSet<CommentLike> CommentLikes { get; init; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new PostMap())
            .ApplyConfiguration(new CommentMap())
            .ApplyConfiguration(new PostLikeMap())
            .ApplyConfiguration(new CommentLikeMap());
    }
}