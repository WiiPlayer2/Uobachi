using System.Diagnostics.CodeAnalysis;
using Uobachi.Domain;

namespace Uobachi.Application;

public interface IIdentity
{
    public UserId? UserId { get; }

    [MemberNotNull(nameof(UserId))]
    public void EnsureAuthenticated()
    {
        if (UserId is null) throw new InvalidOperationException("User is not authenticated");
    }
}