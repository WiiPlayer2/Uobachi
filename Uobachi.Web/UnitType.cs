using HotChocolate.Language;
using HotChocolate.Types;
using LanguageExt;

namespace Uobachi.Web;

public class UnitType() : ScalarType<Unit, StringValueNode>("Unit")
{
    public override IValueNode ParseResult(object? resultValue)
    {
        throw new NotImplementedException();
    }

    protected override Unit ParseLiteral(StringValueNode valueSyntax)
    {
        throw new NotImplementedException();
    }

    protected override StringValueNode ParseValue(Unit runtimeValue)
    {
        throw new NotImplementedException();
    }
}