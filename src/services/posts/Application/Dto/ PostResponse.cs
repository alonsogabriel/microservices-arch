using PostsApi.Domain.Entities;

namespace PostsApi.Application.Dto;

public class PostResponse
{
    public Guid Id { get; init; }
    public Guid AuthorId { get; init; }
    public PostAuthor? Author { get; init; }
    public string Description { get; init; }
    public int LikesCount { get; init; }
    public int CommentsCount { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public static PostResponse From(Post post)
    {
        return new PostResponse
        {
            Id = post.Id,
            AuthorId = post.AuthorId,
            Author = null,
            Description = post.Description,
            LikesCount = post.LikesCount,
            CommentsCount = post.CommentsCount,
            CreatedAt = post.CreatedAt,
            UpdatedAt = post.UpdatedAt
        };
    }
}

public record PostAuthor(string Name, string Username);