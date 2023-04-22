namespace Domain;

public class Outpost
{
    public Guid Id;
    public string Address;
    public string Name;
    public List<Worker> Workers = new List<Worker>();
    public List<ShopProduct> Products = new List<ShopProduct>();
    
    public static Outpost NewOutpost(string name, string address)
    {
        var outpost = new Outpost();
        outpost.Id = Guid.NewGuid();
        outpost.Address = address;
        outpost.Name = name;
        return outpost;
    }
}