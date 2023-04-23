using Domain;
using Services.ServiceInterfaces;

namespace Services;

public class OutpostService : IOutpostService
{
    private readonly IOutpostRepository _outpostRepository;
    private readonly IWorkerRepository _workerRepository;

    public OutpostService(IOutpostRepository outpostRepository, IWorkerRepository workerRepository)
    {
        _outpostRepository = outpostRepository;
        _workerRepository = workerRepository;
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

    public List<Worker> GetWorkers(Guid outpostId)
    {
        List<Worker> workers = new List<Worker>();

        var outpost = _outpostRepository.Get(outpostId);
        if (outpost != null)
        {
            foreach (var workerId in outpost.WorkersId)
            {
                var worker = _workerRepository.Get(workerId);
                if (worker != null)
                {
                    workers.Add(worker);
                }
            }
            
        }

        return workers;
    }

    public void EditWorkers(Guid outpostId, List<Guid> workers)
    {
        _outpostRepository.EditWorkers(new Outpost{Id = outpostId, WorkersId = workers});
    }

    public void AddWorkers(Guid outpostId, Guid workerId)
    {
        throw new NotImplementedException();
    }

    public void RemoveWorker(Guid outpostId, Guid workerId)
    {
        var outpost = _outpostRepository.Get(outpostId);
        if (outpost == null)
            return;

        var worker = _workerRepository.Get(workerId);
        if (worker == null)
            return;

        // if (!worker.OutpostId.Equals(outpost.Id) || !outpost.WorkersId.Contains(worker.Id))
        //     return;
        
        outpost.WorkersId.Remove(worker.Id);
        _outpostRepository.EditWorkers(outpost);

        worker.OutpostId = Guid.Empty;
        _workerRepository.Edit(worker);
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