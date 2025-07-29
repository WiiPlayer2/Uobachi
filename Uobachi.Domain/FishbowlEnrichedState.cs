namespace Uobachi.Domain;

public record FishbowlEnrichedState(IReadOnlyList<User> Users, IReadOnlyList<UserId> Audience, IReadOnlyList<UserId> Bowl, FishbowlConfig Config, ValidStatus ValidStatus);