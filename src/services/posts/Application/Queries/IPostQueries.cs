using PostsApi.Application.Dto;

namespace PostsApi.Application.Queries;

public interface IPostQueries
{
    Task<PostResponse?> FindAsync(Guid postId, CancellationToken cancellationToken = default);
}