using Kontenery.Interfaces;

namespace Kontenery.Containers;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double DeadWeight {get; set; }
    public double Deph {get; set; }
    
   
    public Container(double cargoWeight, double height, double deadWeight, double deph)
    {
        CargoWeight = cargoWeight;
        Height = height;
        DeadWeight = deadWeight;
        Deph = deph;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        
    }
    
}