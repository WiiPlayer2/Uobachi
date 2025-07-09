namespace Uobachi.Domain;

public record FishbowlState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience)
{
    public static FishbowlState New { get; } = new([], []);
}