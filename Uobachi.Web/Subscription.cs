using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Subscription
{
    [Subscribe(With = nameof(SubscribeToState))]
    public FishbowlState GetState([EventMessage] FishbowlState state) => state;

    public IObservable<FishbowlState> SubscribeToState([Service] Store<FishbowlState> store) => store;
}
