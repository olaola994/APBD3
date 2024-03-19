using Kontenery.Interfaces;

namespace Kontenery.Containers;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    
   
    public Container(double cargoWeight, double height)
    {
        CargoWeight = cargoWeight;
        Height = height;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        
    }
    
}