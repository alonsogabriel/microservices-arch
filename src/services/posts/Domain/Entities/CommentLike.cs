namespace PostsApi.Domain.Entities;

public class CommentLike
{
    private CommentLike() {}
    public CommentLike(Guid commentId, Guid userId)
    {
        CreatedAt = DateTime.UtcNow;
        CommentId = commentId;
        UserId = userId;
    }
    public Guid CommentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
}