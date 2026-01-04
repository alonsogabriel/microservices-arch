using PostsApi.Domain.Entities;

namespace PostsApi.Application.Dto;

public record PostResponse(
    Guid Id,
    Guid AuthorId,
    PostAuthor? Author,
    string Description,
    int LikesCount,
    int CommentsCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt)
{
    public static PostResponse From(Post post)
    {
        return new PostResponse(
            post.Id,
            post.AuthorId,
            null,
            post.Description,
            post.LikesCount,
            post.CommentsCount,
            post.CreatedAt,
            post.UpdatedAt);
    }
}

public record PostAuthor(string Name, string Username);