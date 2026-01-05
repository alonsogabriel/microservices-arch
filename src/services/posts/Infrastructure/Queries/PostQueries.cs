using Microsoft.EntityFrameworkCore;
using PostsApi.Application.Dto;
using PostsApi.Application.Queries;

namespace PostsApi.Infrastructure.Queries;

class PostSqlQueries(DataContext context) : IPostQueries
{
    private readonly DataContext _context = context;
    public async Task<PostResponse?> FindAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        return await _context.Posts
            .AsNoTracking()
            .Select(p => new PostResponse
            {
                Id = p.Id,
                AuthorId = p.AuthorId,
                Author = null,
                Description = p.Description,
                LikesCount = p.LikesCount,
                CommentsCount = p.CommentsCount,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            })
            .FirstOrDefaultAsync(p => p.Id == postId, cancellationToken);
    }
}