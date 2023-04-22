using Domain;

namespace Services;

public interface IWorkerRepository
{
    public void Delete(Guid guid);
    public List<Worker> GetAll();
    public Worker? Get(Guid guid);
    public void Add(Worker worker);
    public void Edit(Worker worker);
}