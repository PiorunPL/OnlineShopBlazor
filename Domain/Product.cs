namespace Domain;

public class Product
{
    public Guid ID;
    public string Name;
    public double Price;
    public List<Product> CompatibleWith = new List<Product>();
}