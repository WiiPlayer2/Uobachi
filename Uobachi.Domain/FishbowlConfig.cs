using System;

namespace Uobachi.Domain;

public record FishbowlConfig(int Seats)
{
    public static FishbowlConfig New { get; } = new(3);
}
