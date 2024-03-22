namespace Kontenery.Containers;

public class ProductTemperatureDatabase
{
    private static ProductTemperatureDatabase instance;
    private Dictionary<string, double> productTemperatures;
    
    public ProductTemperatureDatabase()
    {
        productTemperatures = new Dictionary<string, double>();
        productTemperatures.Add("Bananas", 13.3);
        productTemperatures.Add("Chocolate", 18);
        productTemperatures.Add("Fish", 2);
        productTemperatures.Add("Meat", -15);
        productTemperatures.Add("Ice cream", -18);
        productTemperatures.Add("Frozen pizza", -30);
        productTemperatures.Add("Cheese", 7.2);
        productTemperatures.Add("Sausages", 5);
        productTemperatures.Add("Butter", 20.5);
        productTemperatures.Add("Eggs", 19);
    }
    public static ProductTemperatureDatabase Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProductTemperatureDatabase();
            }
            return instance;
        }
    }


    public void addProduct(string name, double temperature)
    {
        if (productTemperatures.ContainsKey(name))
        {
            throw new ArgumentException("Product exists in database");
        }
        productTemperatures.Add(name, temperature);
    }

    public double getTemperature(string name)
    {
        if (!productTemperatures.ContainsKey(name))
        {
            throw new ArgumentException("Product doesn't exists in database");
        }

        return productTemperatures[name];
    }
}