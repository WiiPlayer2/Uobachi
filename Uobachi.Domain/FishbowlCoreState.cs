namespace Uobachi.Domain;

public record FishbowlCoreState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience, IReadOnlyList<UserId> Bowl, FishbowlConfig Config)
{
    public static FishbowlCoreState New { get; } = new([], [], [], FishbowlConfig.New);
}