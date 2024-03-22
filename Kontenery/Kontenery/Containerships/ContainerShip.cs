using Kontenery.Containers;

namespace Kontenery.Containerships;

public class ContainerShip
{
    protected List<Container> ContainerList = new List<Container>();
    protected double MaxSpped { get; set; }
    protected int MaxCarrige { get; set; }
    protected double MaxContainersWeight { get; set; }
    protected double ConvertedMaxWeight { get; set; }
    protected double CurrentWeight { get; set; }

    public ContainerShip(double maxSpped, int maxCarrige, double maxContainersWeight)
    {
        MaxSpped = maxSpped;
        MaxCarrige = maxCarrige;
        MaxContainersWeight = maxContainersWeight;
        ConvertedMaxWeight = MaxContainersWeight * 1000;
        CurrentWeight = ConvertedMaxWeight;
    }
    
    public void AddContainer(Container container)
    {
        CurrentWeight -= (container.CargoWeight + container.DeadWeight);
        if (CurrentWeight < 0 )
        {
            throw new Exception("Can't add container because it's too heavy");
        }
        else if(MaxCarrige - 1 < 0) throw new Exception("Can't add container because there is no space");
        MaxCarrige--;
        ContainerList.Add(container);
        Console.WriteLine($"Container added, current weight {CurrentWeight}");
    }

    public void DeleteContainer(Container container)
    {
        if (ContainerList != null)
        {
            CurrentWeight += container.CargoWeight + container.DeadWeight;
            MaxCarrige++;
            ContainerList.Remove(container);
            Console.WriteLine($"Container deleted, current weight {CurrentWeight}");
        }
        else
        {
            throw new Exception("Container list is empty.");
        }
    }

    public void ReplaceContainer(string oldContainerSerialNumber, Container newContainer)
    {
        Container containerToReplace = null;
        foreach (var container in ContainerList)
        {
            if (container.SerialNumber == oldContainerSerialNumber)
            {
                containerToReplace = container;
                break;
            }
        }

        if (containerToReplace != null)
        {
            DeleteContainer(containerToReplace);
            AddContainer(newContainer);
            Console.WriteLine($"Container replaced, current weight {CurrentWeight}");
        }
    }

    public void CintainerTransfer(Container container, ContainerShip ship1, ContainerShip ship2)
    {
        ship1.DeleteContainer(container);
        ship2.AddContainer(container);
        Console.WriteLine($"Container transfered, current weight {CurrentWeight}");
    }

    public void info()
    {
        Console.WriteLine($"Ship MaxSpped: {MaxSpped} - MaxCarrige: {MaxCarrige}(tons)");
        Console.WriteLine("Conteinership list");
        foreach (var container in ContainerList)
        {
            dynamic dynamicContainer = container;
            dynamicContainer.info();
            Console.WriteLine("\n");
        }
    }
    
}