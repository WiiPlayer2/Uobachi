namespace Uobachi.Domain;

public record FishbowlState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience, IReadOnlyList<UserId> Bowl, FishbowlConfig Config, ValidStatus ValidStatus);