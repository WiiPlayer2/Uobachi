using LanguageExt;
using Uobachi.Domain;

namespace Uobachi.Application;

public class Fishbowl(IIdentity identity, FishbowlStore store)
{
    public UserId Join()
    {
        identity.EnsureAuthenticated();
        store.Apply(FishbowlStateAction.AddUser(identity.UserId));
        return identity.UserId;
    }
    
    public void Switch()
    {
        identity.EnsureAuthenticated();   
        store.Apply(FishbowlStateAction.SwitchPosition(identity.UserId));
    }

    public void ConfigureSeats(int seats) => store.Apply(FishbowlStateAction.ConfigureSeats(seats));

    public FishbowlState Current => store.Current;

    public IObservable<FishbowlState> Updates => store;
    
    public Option<User> User => store.Current.Users.FirstOrDefault(x => x.Id == identity.UserId);
}