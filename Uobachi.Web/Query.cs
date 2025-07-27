using LanguageExt;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class Query
{
    public FishbowlState GetFishbowl([Service] Fishbowl fishbowl) => fishbowl.Current;
}
