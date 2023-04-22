using Domain;

namespace Services.ServiceInterfaces;

public interface IWorkerService
{
    public List<Worker> GetAll();
    public void Add(string firstName, string lastName, Outpost? outpost);
    public Worker? Get(Guid id);
    public void Delete(Guid id);
    public void Edit(Guid id, string firstName, string lastName, Outpost? outpost);
}