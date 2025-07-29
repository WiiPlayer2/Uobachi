using Microsoft.Extensions.DependencyInjection;
using Uobachi.Domain;

namespace Uobachi.Application;

public static class DI
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<Fishbowl>();
        services.AddSingleton(new Store<FishbowlState, FishbowlStateAction>(FishbowlState.New, FishbowlStateReducer.Apply));
    }
}
