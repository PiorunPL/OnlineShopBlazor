namespace Domain;

public class Order
{
    public Guid Id;
    public List<ShopProduct> Products = new List<ShopProduct>();
    public String status;
    public Guid Client;
}