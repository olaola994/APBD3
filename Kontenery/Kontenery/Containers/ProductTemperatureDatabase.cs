namespace Kontenery.Containers;

public class ProductTemperatureDatabase
{
    private static ProductTemperatureDatabase instance;
    private Dictionary<string, double> productTemperatures;
    
    public ProductTemperatureDatabase()
    {
        productTemperatures = new Dictionary<string, double>();
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