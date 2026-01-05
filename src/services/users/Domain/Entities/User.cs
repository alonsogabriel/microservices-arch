namespace UsersApi.Domain.Entities;

public enum Status { None, Online, Offline, Invisible, Busy, DoNotDisturb, Away };

public class User
{
    private User() { }
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public Guid PersonId { get; private set; }
    public Person Person { get; private set; }
    public Status Status { get; private set; } = default;
    public string? About { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}
