using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Subscription
{
    [Subscribe(With = nameof(SubscribeToFishbowl))]
    public FishbowlState GetFishbowl([EventMessage] FishbowlState state) => state;

    public IObservable<FishbowlState> SubscribeToFishbowl([Service] Fishbowl fishbowl) => fishbowl.Updates;

    [Subscribe(With = nameof(SubscribeToMe))]
    public User GetMe([EventMessage] User me) => me;

    public IObservable<User> SubscribeToMe([Service] Fishbowl fishbowl) => fishbowl.UserUpdates;
}
