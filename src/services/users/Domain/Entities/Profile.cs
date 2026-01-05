namespace UsersApi.Domain.Entities;

public class Profile
{
    public const int BioMaxLength = 3000;
    public const int MaxInterests = 7;
    private readonly List<ProfileInterest> _interests = [];
    private Profile() { }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public VisibilityStatus Visibility { get; private set; }
    public string Bio { get; private set; }
    public long FollowersCount { get; private set; }
    public long FollowingCount { get; private set; }
    public IReadOnlyList<ProfileInterest> Interests => _interests;
    public IEnumerable<Interest> GetInterests() => _interests.Select(i => i.Interest);
    public string? Profession { get; private set; }
    public string? Company { get; private set; }
}