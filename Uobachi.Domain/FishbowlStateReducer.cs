namespace Uobachi.Domain;

public static class FishbowlStateReducer
{
    public static FishbowlCoreState Apply(this FishbowlCoreState source, FishbowlStateAction action) =>
        action.Match(
            source.AddUser,
            source.ConfigureSeats,
            source.SwitchPosition);

    private static FishbowlCoreState ConfigureSeats(this FishbowlCoreState source,
        FishbowlStateAction.ConfigureSeats_ configureSeats) => source with
    {
        Config = source.Config with
        {
            Seats = configureSeats.Seats,
        },
    };

    private static FishbowlCoreState AddUser(this FishbowlCoreState source, FishbowlStateAction.AddUser_ addUser) => source with
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

    private static FishbowlCoreState SwitchPosition(this FishbowlCoreState source, FishbowlStateAction.SwitchPosition_ switchPosition) =>
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