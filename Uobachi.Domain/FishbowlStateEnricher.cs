namespace Uobachi.Domain;

public static class FishbowlStateEnricher
{
    public static FishbowlEnrichedState Transform(FishbowlState state)
    {
        return new(state.Users, state.Audience, state.Bowl, state.Config, state.Bowl.Count < state.Config.Seats
            ? ValidStatus.TooFew
            : state.Users.Count > state.Config.Seats
                ? ValidStatus.TooMany
                : ValidStatus.Valid);
    }
}