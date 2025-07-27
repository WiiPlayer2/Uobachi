using LanguageExt;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Query
{
    public User GetMe([Service] Fishbowl fishbowl) => fishbowl.User;
    
    public FishbowlState GetFishbowl([Service] Fishbowl fishbowl) => fishbowl.Current;
}
