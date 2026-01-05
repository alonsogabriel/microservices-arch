namespace UsersApi.Domain.Entities;

public class ProfileSettings
{
    private ProfileSettings() {}
    public VisibilityStatus ProfessionVisibility { get; internal set; } = VisibilityStatus.Public;
    public VisibilityStatus CompanyVisibility { get; internal set; } = VisibilityStatus.Public;
    public VisibilityStatus InterestsVisibility { get; private set; } = VisibilityStatus.Public;
}