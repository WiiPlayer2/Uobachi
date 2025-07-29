using Uobachi.Domain;

namespace Uobachi.Application;

public class FishbowlStore() : Store<FishbowlCoreState, FishbowlStateAction, FishbowlState>(
    FishbowlCoreState.New,
    FishbowlStateReducer.Apply,
    FishbowlStateEnricher.Enrich
);