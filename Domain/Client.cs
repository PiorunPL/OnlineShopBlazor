namespace Domain;

public class Clients
{
    public Guid ID;
    public string FirstName;
    public string LastName;
    public string EmailAddress;
    // public string Password;
    public ShoppingCart ShoppingCart;
    public List<Order> Orders;
}