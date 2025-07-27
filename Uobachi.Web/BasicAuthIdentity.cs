using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Uobachi.Application;
using Uobachi.Domain;

namespace Uobachi.Web;

public class BasicAuthIdentity : IIdentity
{
    public BasicAuthIdentity(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext is not {} httpContext) return;
        if (httpContext.Request.Headers.Authorization is not { Count: 1} authorizationHeader) return;
        if (!AuthenticationHeaderValue.TryParse(authorizationHeader[0], out var authenticationHeaderValue)) return;
        if (authenticationHeaderValue.Scheme != "Basic") return;
        
        var data = new byte[1024];
        if(!Convert.TryFromBase64String(authenticationHeaderValue.Parameter ?? string.Empty, data, out var bytesWritten)) return;
        
        // var basicAuthData = Encoding.UTF8.GetString(data, 0, bytesWritten);
        // var basicAuthSplits = basicAuthData.Split(':');
        // if (basicAuthSplits.Length != 2) return;

        var hash = SHA256.HashData(data.AsSpan(0, bytesWritten));
        var userId = new Guid(hash.AsSpan(0, 16));
        UserId = UserId.From(userId);
    }

    public UserId? UserId { get; }
}
