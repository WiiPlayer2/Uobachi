using Uobachi.Domain;

namespace Uobachi.Application;

public class Fishbowl(IIdentity identity, Store<FishbowlState> store)
{
    public UserId Join()
    {
        identity.EnsureAuthenticated();
        store.Apply(s => s.AddUser(identity.UserId));
        return identity.UserId;
    }
    
    public void Switch()
    {
        identity.EnsureAuthenticated();   
        store.Apply(s => s.SwitchPosition(identity.UserId));
    }

    public FishbowlState Current => store.Current;
    
    public User User => store.Current.Users.First(x => x.Id == identity.UserId);
}