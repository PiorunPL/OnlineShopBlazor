using Domain;
using Services.ServiceInterfaces;

namespace Services;

public class OutpostService : IOutpostService
{
    private readonly IOutpostRepository _outpostRepository;

    public OutpostService(IOutpostRepository outpostRepository)
    {
        _outpostRepository = outpostRepository;
    }

    public List<Outpost> GetAll()
    {
        return _outpostRepository.GetAll(); 
    }

    public void Add(string name, string address)
    {
        _outpostRepository.Add(Outpost.NewOutpost(name, address));
    }

    public Outpost? Get(Guid Id)
    {
        return _outpostRepository.Get(Id);
    }

    public void Delete(Guid Id)
    {
        _outpostRepository.Delete(Id);
    }

    public void Edit(Guid id, string name, string address)
    {
        var tempOutpost = new Outpost
        {
            Address = address,
            Id = id,
            Name = name
        };
        _outpostRepository.Edit(tempOutpost);
    }

    public void EditWorkers(Guid outpostId, List<Worker> workers)
    {
        _outpostRepository.EditWorkers(new Outpost{Id = outpostId, Workers = workers});
    }

    public void AddWorkers(Guid outpostId, Guid workerId)
    {
        throw new NotImplementedException();
    }

    public void RemoveWorker(Guid outpostId, Guid workerId)
    {
        throw new NotImplementedException();
    }

    public void EditProducts(Guid outpostId, List<Product> products)
    {
        throw new NotImplementedException();
    }

    public void AddProducts(Guid outpostId, Guid productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public void RemoveProducts(Guid outpostId, Guid productId, int quantity)
    {
        throw new NotImplementedException();
    }
}