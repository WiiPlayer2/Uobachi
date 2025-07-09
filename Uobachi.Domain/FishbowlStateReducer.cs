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
            userId,
        ],
    };
}