using PostsApi.Domain.Entities;

namespace PostsApi.Domain.Repositories;

public interface IPostRepository
{
    Task AddAsync(Post post, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid postId, CancellationToken cancellationToken = default);
    Task IncrementLikesAsync(Guid postId, int count = 1, CancellationToken cancellationToken = default);
}