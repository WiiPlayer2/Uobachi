using System;
using FunicularSwitch.Generators;
// ReSharper disable InconsistentNaming

namespace Uobachi.Domain;

[UnionType(CaseOrder = CaseOrder.Alphabetic)]
public abstract partial record FishbowlStateAction
{
    public partial record AddUser_(UserId UserId) : FishbowlStateAction;
    
    public partial record SwitchPosition_(UserId UserId) : FishbowlStateAction;

    public partial record ConfigureSeats_(int Seats) : FishbowlStateAction;
}
