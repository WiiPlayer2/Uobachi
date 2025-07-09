namespace Uobachi.Domain;

public record User(UserId Id)
{
    public static User New(UserId id) => new(id);
}