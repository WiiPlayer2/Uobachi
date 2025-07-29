namespace Uobachi.Domain;

public static class FishbowlStateReducer
{
    public static FishbowlState Apply(this FishbowlState source, FishbowlStateAction action) =>
        action.Match(
            source.AddUser,
            source.SwitchPosition);
    
    private static FishbowlState AddUser(this FishbowlState source, FishbowlStateAction.AddUser_ addUser) => source with
    {
        Users =
        [
            ..source.Users,
            User.New(addUser.UserId),
        ],
        Audience = [
            ..source.Audience,
            addUser.UserId,
        ],
    };

    private static FishbowlState SwitchPosition(this FishbowlState source, FishbowlStateAction.SwitchPosition_ switchPosition) =>
        source.Audience.Contains(switchPosition.UserId)
            ? source with
            {
                Audience = source.Audience.Except([switchPosition.UserId]).ToList(),
                Bowl =
                [
                    ..source.Bowl,
                    switchPosition.UserId,
                ],
            }
            : source with
            {
                Audience =
                [
                    ..source.Audience,
                    switchPosition.UserId,
                ],
                Bowl = source.Bowl.Except([switchPosition.UserId]).ToList(),
            };
}