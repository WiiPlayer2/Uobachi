using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Mutation
{
    public UserId Join([Service] Fishbowl fishbowl) => fishbowl.Join();

    public bool Switch(UserId userId, [Service] Fishbowl fishbowl)
    {
        fishbowl.Switch(userId);
        return true;
    }
}
