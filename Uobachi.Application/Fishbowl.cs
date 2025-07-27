using Uobachi.Domain;

namespace Uobachi.Application;

public class Fishbowl(Store<FishbowlState> store)
{
    public UserId Join()
    {
        var userId = UserId.New();
        store.Apply(s => s.AddUser(userId));
        return userId;
    }
    
    public void Switch(UserId userId) => store.Apply(s => s.SwitchPosition(userId));
    
    public FishbowlState Current => store.Current;
}