using HotChocolate;
using LanguageExt;
using Uobachi.Application;
using Uobachi.Domain;
using static LanguageExt.Prelude;

namespace Uobachi.Web;

public class Mutation
{
    public Unit Join([Service] Fishbowl fishbowl)
    {
        fishbowl.Join();
        return unit;
    }

    public Unit Switch([Service] Fishbowl fishbowl)
    {
        fishbowl.Switch();
        return unit;
    }

    public Unit ConfigureSeats([Service] Fishbowl fishbowl, int seats)
    {
        fishbowl.ConfigureSeats(seats);
        return unit;
    }

    public Unit UpdateUser([Service] Fishbowl fishbowl, UserName name)
    {
        fishbowl.UpdateUser(name);
        return unit;
    }
}
