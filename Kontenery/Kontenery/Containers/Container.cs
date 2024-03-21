using Kontenery.Exeptions;
using Kontenery.Interfaces;

namespace Kontenery.Containers;

public abstract class Container : IContainer
{
    private static int _nextSerialNumber = 1;
    private readonly string _serialNumber;
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double DeadWeight {get; set; }
    public double Deph {get; set; }
    public double MaxLoadCapacity { get; set; }
    public string SerialNumber => _serialNumber;
    
   
    protected Container(double cargoWeight, double height, double deadWeight, double deph, double maxLoadCapacity)
    {
        CargoWeight = cargoWeight;
        Height = height;
        DeadWeight = deadWeight;
        Deph = deph;
        MaxLoadCapacity = maxLoadCapacity;
        _serialNumber = GenerateSerialNumber();
    }

    public abstract void Unload();
    public abstract void Load(double cargoWeight);
    protected abstract string GetTypeIdentifier();

    private string GenerateSerialNumber()
    {
        string typeIdentifier = GetTypeIdentifier();
        string serialNumber = $"KON-{typeIdentifier}-{_nextSerialNumber}";
        _nextSerialNumber++;
        return serialNumber;
    }
    
}