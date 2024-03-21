using Kontenery.Exeptions;

namespace Kontenery.Containers;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoWeight, double height, double deadWeight, double deph) : base(cargoWeight, height, deadWeight, deph)
    {
        
    }

    public new void Load(double cargoWeight)
    {
        throw new OverfillException();
    }
}