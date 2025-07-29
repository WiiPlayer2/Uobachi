using Uobachi.Domain;

namespace Uobachi.Application;

public class FishbowlStore() : Store<FishbowlState, FishbowlStateAction>(
    FishbowlState.New,
    FishbowlStateReducer.Apply
);