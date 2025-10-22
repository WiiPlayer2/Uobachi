using HotChocolate;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Query
{
    public User? GetMe([Service] Fishbowl fishbowl) => fishbowl.User.ValueUnsafe();
    
    public FishbowlState GetFishbowl([Service] Fishbowl fishbowl) => fishbowl.Current;
}
