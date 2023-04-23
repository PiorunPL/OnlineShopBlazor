using Domain;
using Services;

namespace External.Repository;

public class WorkerRepositoryList : IWorkerRepository
{
    private List<Worker> _workers = new List<Worker>();

    public WorkerRepositoryList()
    {
        _workers.Add(Worker.CreateNew("Andrzej", "Piotrowski"));
        _workers.Add(Worker.CreateNew("Piotr", "Małolepszy"));
        _workers.Add(Worker.CreateNew("Bogusław", "Linda"));
    }
    
    
    public void Delete(Guid guid)
    {
        var foundWorker = Get(guid);
        if (foundWorker != null)
            _workers.Remove(foundWorker);
    }

    public List<Worker> GetAll()
    {
        return _workers.ToList();
    }

    public Worker? Get(Guid guid)
    {
        return _workers.FirstOrDefault(worker => worker.Id == guid);
    }

    public void Add(Worker worker)
    {
        var foundWorker = Get(worker.Id);
        if(foundWorker == null)
            _workers.Add(worker);
    }

    public void Edit(Worker worker)
    {
        var foundWorker = Get(worker.Id);
        if (foundWorker == null)
            return;
        foundWorker.OutpostId = worker.OutpostId;
        foundWorker.FirstName = worker.FirstName;
        foundWorker.LastName = worker.LastName;
    }
}