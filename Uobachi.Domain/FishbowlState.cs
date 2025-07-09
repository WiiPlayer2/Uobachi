namespace Uobachi.Domain;

public record FishbowlState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience, IReadOnlyList<UserId> Bowl)
{
    public static FishbowlState New { get; } = new([], [], []);
}