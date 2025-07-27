namespace Uobachi.Domain;

public static class FishbowlStateReducer
{
    public static FishbowlState AddUser(this FishbowlState source, UserId userId) => source with
    {
        Users =
        [
            ..source.Users,
            User.New(userId),
        ],
        Audience = [
            ..source.Audience,
            userId,
        ],
    };

    public static FishbowlState SwitchPosition(this FishbowlState source, UserId userId) =>
        source.Audience.Contains(userId)
            ? source with
            {
                Audience = source.Audience.Except([userId]).ToList(),
                Bowl =
                [
                    ..source.Bowl,
                    userId,
                ],
            }
            : source with
            {
                Audience =
                [
                    ..source.Audience,
                    userId,
                ],
                Bowl = source.Bowl.Except([userId]).ToList(),
            };
}