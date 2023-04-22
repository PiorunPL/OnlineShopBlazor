using Domain;

namespace Services;

public interface IOutpostRepository
{
    public void Delete(Guid guid);
    public List<Outpost> GetAll();
    public Outpost? Get(Guid guid);
    public void Add(Outpost outpost);
    public void Edit(Outpost outpost);
    public void EditWorkers(Outpost outpost);
}