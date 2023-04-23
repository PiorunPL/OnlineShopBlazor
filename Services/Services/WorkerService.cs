using Domain;
using Services.ServiceInterfaces;

namespace Services;

public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IOutpostRepository _outpostRepository;

    public WorkerService(IWorkerRepository workerRepository, IOutpostRepository outpostRepository)
    {
        _workerRepository = workerRepository;
        _outpostRepository = outpostRepository;
    }
    
    public List<Worker> GetAll()
    {
        return _workerRepository.GetAll();
    }

    public void Add(string firstName, string lastName, Outpost? outpost)
    {
        //Prevents from Worker having same ID
        var worker = Worker.CreateNew(firstName, lastName);
        var workerWithSameId = _workerRepository.Get(worker.Id);
        while (workerWithSameId != null)
        {
            worker = Worker.CreateNew(firstName, lastName);
            workerWithSameId = _workerRepository.Get(worker.Id);
        }
        
        if (outpost == null)
            worker.OutpostId = Guid.Empty;
        else
        {
            var foundOutpost = _outpostRepository.Get(outpost.Id);
            if (foundOutpost != null)
            {
                worker.OutpostId = foundOutpost.Id;
                foundOutpost.WorkersId.Add(worker.Id);
                _outpostRepository.Edit(foundOutpost);
            }
        }
        _workerRepository.Add(worker);
    }

    public Worker? Get(Guid id)
    {
        return _workerRepository.Get(id);
    }

    public void Delete(Guid id)
    {
        var foundWorker = _workerRepository.Get(id);
        if (foundWorker == null)
            return;
        
        var outpost = _outpostRepository.Get(foundWorker.OutpostId);
        if (outpost != null)
        {
            outpost.WorkersId.Remove(foundWorker.Id);
            _outpostRepository.Edit(outpost);
        }

        _workerRepository.Delete(id);
    }

    public void Edit(Guid id, string firstName, string lastName, Outpost? outpost)
    {
        var foundWorker = _workerRepository.Get(id);
        
        if (foundWorker == null)
            return;
        
        foundWorker.FirstName = firstName;
        foundWorker.LastName = lastName;
        
        Guid outpostId;
        if (outpost == null)
            outpostId = Guid.Empty;
        else
            outpostId = outpost.Id;

        if (!foundWorker.OutpostId.Equals(outpostId))
        {
            var oldOutpost = _outpostRepository.Get(foundWorker.OutpostId);
            if (oldOutpost != null)
            {
                oldOutpost.WorkersId.Remove(foundWorker.Id);
                _outpostRepository.Edit(oldOutpost);
                foundWorker.OutpostId = Guid.Empty;
            }

            var newOutpost = _outpostRepository.Get(outpostId);
            if (newOutpost != null)
            {
                newOutpost.WorkersId.Add(foundWorker.Id);
                _outpostRepository.Edit(newOutpost);
                foundWorker.OutpostId = newOutpost.Id;
            }
        }
        
        _workerRepository.Edit(foundWorker);
    }
}