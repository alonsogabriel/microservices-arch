namespace UsersApi.Domain.Entities;

public enum Interest {
    Sports, Music, Games, TvShows, News, Politics, Football, Food, Travel, Nature, Calisthenics,
    Books, Motorsport, Basketball, Baseball, Voleyball, Gym, AmericanFootball, CrossFit };

public class ProfileInterest
{
    private ProfileInterest() {}
    public Guid Id { get; private set; }
    public Guid ProfileId { get; private set; }
    public Interest Interest { get; private set; }
}