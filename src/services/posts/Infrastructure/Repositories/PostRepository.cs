using Microsoft.EntityFrameworkCore;
using PostsApi.Domain.Entities;
using PostsApi.Domain.Repositories;

namespace PostsApi.Infrastructure.Repositories;

class PostRepository(DataContext context) : IPostRepository
{
    private readonly DataContext _context = context;
    public async Task AddAsync(Post post, CancellationToken cancellationToken = default)
    {
        await _context.Posts.AddAsync(post, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        return await _context.Posts.AnyAsync(e => e.Id == postId, cancellationToken);
    }

    public async Task IncrementLikesAsync(Guid postId, int count = 1, CancellationToken cancellationToken = default)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $@"UPDATE ""Post"" SET ""LikesCount"" = ""LikesCount"" + {count} WHERE ""Id"" = {postId}", cancellationToken);
    }
}