namespace PostsApi.Domain.Entities;

public class Post
{
    public const int MaxDescriptionLength = 3000;
    private Post() {}
    public Post(Guid authorId, string description)
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTime.UtcNow;
        Description = description;
        AuthorId = authorId;
    }
    public Guid Id { get; private set; }
    public Guid AuthorId { get; private set; }
    public string Description { get; private set; }
    public int LikesCount { get; private set; }
    public int CommentsCount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Comment Comment(Guid authorId, string content)
    {
        return new Comment(authorId, this.Id, null, content);
    }
}