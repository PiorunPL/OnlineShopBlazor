using Domain;
using Services.ServiceInterfaces;

namespace Services;

public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }
    
    public List<Worker> GetAll()
    {
        return _workerRepository.GetAll();
    }

    public void Add(string firstName, string lastName, Outpost? outpost)
    {
        var worker = Worker.CreateNew(firstName, lastName);
        worker.Outpost = outpost;
        
        //TODO Add to Outpost
        _workerRepository.Add(worker);
    }

    public Worker? Get(Guid id)
    {
        return _workerRepository.Get(id);
    }

    public void Delete(Guid id)
    {
        _workerRepository.Delete(id);
    }

    public void Edit(Guid id, string firstName, string lastName, Outpost? outpost)
    {
        var worker = new Worker(id, firstName, lastName);
        worker.Outpost = outpost;
        _workerRepository.Edit(worker);
    }
}