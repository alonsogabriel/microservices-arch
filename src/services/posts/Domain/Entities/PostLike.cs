namespace PostsApi.Domain.Entities;

public class PostLike
{
    private PostLike() {}
    public PostLike(Guid postId, Guid userId)
    {
        CreatedAt = DateTime.UtcNow;
        PostId = postId;
        UserId = userId;
    }
    public Guid PostId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
}