using Uobachi.Application;

namespace Uobachi.Web;

public static class DI
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IIdentity, BasicAuthIdentity>();
    }
}
