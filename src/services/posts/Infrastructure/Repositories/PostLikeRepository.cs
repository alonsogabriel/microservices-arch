using Microsoft.EntityFrameworkCore;
using PostsApi.Domain.Entities;
using PostsApi.Domain.Repositories;

namespace PostsApi.Infrastructure.Repositories;

class PostLikeRepository(DataContext context) : IPostLikeRepository
{
    private readonly DataContext _context = context;
    public async Task AddAsync(PostLike like, CancellationToken cancellationToken = default)
    {
        await _context.PostLikes.AddAsync(like, cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid postId, Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.PostLikes.AnyAsync(l => l.PostId == postId && l.UserId == userId, cancellationToken);
    }
}