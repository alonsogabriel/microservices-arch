namespace IdentityApi.Domain.Entities;

public class User
{
    private User() { }
    public User(string username, string email, string name, string? phoneNumber)
    {
        Id = Guid.CreateVersion7();
        CreatedAt = DateTime.UtcNow;

        ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(username));
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        if (phoneNumber != null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
        }

        Username = username;
        Email = email;
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Name { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
}