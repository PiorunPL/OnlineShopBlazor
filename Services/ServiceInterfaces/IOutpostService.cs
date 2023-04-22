using Domain;

namespace Services.ServiceInterfaces;

public interface IOutpostService
{
    public List<Outpost> GetAll();
    public void Add(string name, string address);
    public Outpost? Get(Guid Id);
    public void Delete(Guid Id);
    public void Edit(Guid id, string name, string address);
    
    // Workers
    public void EditWorkers(Guid outpostId, List<Worker> workers);
    public void AddWorkers(Guid outpostId, Guid workerId);
    public void RemoveWorker(Guid outpostId, Guid workerId);
    
    //Products
    public void EditProducts(Guid outpostId, List<Product> products);
    public void AddProducts(Guid outpostId, Guid productId, int quantity);
    public void RemoveProducts(Guid outpostId, Guid productId, int quantity);
    
}