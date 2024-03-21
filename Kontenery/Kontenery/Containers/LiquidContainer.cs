using Kontenery.Exeptions;
using Kontenery.Interfaces;

namespace Kontenery.Containers;


public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsDangerous { get; private set; }
    public double Capacity { get; private set; }
    
    public double CurrentCapacity { get; set; }

    public LiquidContainer(double cargoWeight, double height, double deadWeight, double deph, double maxLoadCapacity, bool isDangerous) 
        : base(cargoWeight, height, deadWeight, deph, maxLoadCapacity)
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

    public override void Load(double cargoWeight)
    {
        if (cargoWeight + CurrentCapacity > Capacity)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException();
        }
        else
        {
            CurrentCapacity += cargoWeight;
        }
    }

    public override void Unload()
    {
        CurrentCapacity = 0;
    }

    protected override string GetTypeIdentifier()
    {
        return "L";
    }

    public void NotifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous Liquid Container serial no. {containerSerialNumber}");
    }
}