namespace Uobachi.Domain;

public record FishbowlState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience, IReadOnlyList<UserId> Bowl, FishbowlConfig Config)
{
    public static FishbowlState New { get; } = new([], [], [], FishbowlConfig.New);
}

public record FishbowlConfig(int Seats)
{
    public static FishbowlConfig New { get; } = new(3);
}