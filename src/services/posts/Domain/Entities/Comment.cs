namespace PostsApi.Domain.Entities;

public class Comment
{
    public const int MaxContentLength = 1000;
    private Comment() {}
    public Comment(Guid authorId, Guid postId, Comment? replied, string content)
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTime.UtcNow;
        AuthorId = authorId;
        PostId = postId;
        Replied = replied;
        RepliedId = replied?.Id;
        Content = content;
    }
    public Guid Id { get; private set; }
    public Guid AuthorId { get; private set; }
    public Guid PostId { get; private set; }
    public string Content { get; private set; }
    public int LikesCount { get; private set; }
    public int RepliesCount { get; private set; }
    public Guid? RepliedId { get; private set; }
    public Comment? Replied { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Comment Reply(Guid authorId, string content)
    {
        return new Comment(authorId, this.PostId, this, content);
    }
}