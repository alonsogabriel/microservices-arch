using PostsApi.Domain.Entities;

namespace PostsApi.Domain.Repositories;

public interface IPostLikeRepository
{
    Task AddAsync(PostLike like, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid postId, Guid userId, CancellationToken cancellationToken = default);
}