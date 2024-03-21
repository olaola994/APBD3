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
    public double Depth {get; set; }
    public double MaxLoadCapacity { get; set; }
    public string SerialNumber => _serialNumber;
    
   
    protected Container(double height, double deadWeight, double depth, double maxLoadCapacity)
    {
        if (height < 0 || deadWeight < 0 || depth < 0 || maxLoadCapacity < 0)
        {
            throw new ArgumentException("Arguments must be non-negative numbers.");
        }
        CargoWeight = 0;
        Height = height;
        DeadWeight = deadWeight;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;
        _serialNumber = GenerateSerialNumber();
    }

    public abstract void Unload();

    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight <= 0) throw new ArgumentException("Cargo weight must be a positive value.");
    }
    protected abstract string GetTypeIdentifier();

    private string GenerateSerialNumber()
    {
        string typeIdentifier = GetTypeIdentifier();
        string serialNumber = $"KON-{typeIdentifier}-{_nextSerialNumber}";
        _nextSerialNumber++;
        return serialNumber;
    }
    
}