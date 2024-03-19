using Kontenery.Exeptions;

namespace Kontenery.Containers;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoWeight, double height) : base(cargoWeight, height)
    {
        
    }

    public new void Load(double cargoWeight)
    {
        throw new OverfillException();
    }
}