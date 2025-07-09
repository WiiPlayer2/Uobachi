using Vogen;

namespace Uobachi.Domain;

[ValueObject<Guid>]
public partial record UserId
{
    public static UserId New() => From(Guid.NewGuid());
}