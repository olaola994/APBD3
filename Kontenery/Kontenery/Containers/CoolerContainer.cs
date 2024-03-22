using Kontenery.Exeptions;
namespace Kontenery.Containers;


public class CoolerContainer: Container
{
    ProductTemperatureDatabase productDatabase = ProductTemperatureDatabase.Instance;
    public string ProductType { get; }
    public double RequiredTemperature { get; }
    
    public CoolerContainer(double height, double deadWeight, double depth, double maxLoadCapacity, string productType, double containerTemperature) :
        base(height, deadWeight, depth, maxLoadCapacity)
    {
        ProductType = productType;
        RequiredTemperature = productDatabase.getTemperature(productType);
        if (containerTemperature < RequiredTemperature)
        {
            throw new ArgumentException($"The temperature of the container is too low for {productType}");
        }
    }
    public void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        if (cargoWeight + CargoWeight > MaxLoadCapacity)
        {
            throw new OverfillException();
        }else
        {
            CargoWeight += cargoWeight;
            Console.WriteLine($"C Container loaded, current weight: {CargoWeight}");
        }
    }

    public override void Unload()
    {
        CargoWeight = 0;
        Console.WriteLine($"C Container unloaded, current weight: {CargoWeight}");
    }

    protected override string GetTypeIdentifier()
    {
        return "C";
    }
    public void info()
    {
        base.info();
        Console.WriteLine($"ProductType: {ProductType} - RequiredTemperature: {RequiredTemperature}\n");
    }
}