using Kontenery.Exeptions;
using Kontenery.Interfaces;

namespace Kontenery.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double height, double deadWeight, double depth, double maxLoadCapacity,
        double pressure) :
        base(height, deadWeight, depth, maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        CargoWeight *= CargoWeight * 0.05;
    }

    public void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        if (cargoWeight + CargoWeight > MaxLoadCapacity)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException();
        }else
        {
            CargoWeight += cargoWeight;
        }
    }

    protected override string GetTypeIdentifier()
    {
        return "G";
    }
    public void NotifyHazard(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous action. Gas Container serial no. {containerSerialNumber}");
    }
}