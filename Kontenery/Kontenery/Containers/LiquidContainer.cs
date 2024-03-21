using Kontenery.Exeptions;
using Kontenery.Interfaces;

namespace Kontenery.Containers;


public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous { get; private set; }
    public double Capacity { get; private set; }

    public LiquidContainer(double height, double deadWeight, double depth, double maxLoadCapacity, bool isDangerous) 
        : base(height, deadWeight, depth, maxLoadCapacity)
    {
        IsDangerous = isDangerous;
        
        if (IsDangerous)
        {
            Capacity = maxLoadCapacity * 0.5;
        }
        else
        {
            Capacity = maxLoadCapacity * 0.9;
        }
    }

    public void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        if (cargoWeight + CargoWeight > Capacity)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException();
        }
        else
        {
            CargoWeight += cargoWeight;
        }
    }

    public override void Unload()
    {
        CargoWeight = 0;
    }

    protected override string GetTypeIdentifier()
    {
        return "L";
    }

    public void NotifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous action. Liquid Container serial no. {containerSerialNumber}");
    }
}