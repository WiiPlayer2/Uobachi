namespace Uobachi.Domain;

public record User(UserId Id, UserName Name)
{
    public static User New(UserId id) => new(id, UserName.From(id.ToString()));
}