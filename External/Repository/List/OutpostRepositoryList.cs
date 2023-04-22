using Domain;
using Services;

namespace External.Repository;

public class OutpostRepositoryList : IOutpostRepository
{
    private List<Outpost> _outposts = new List<Outpost>();
    public OutpostRepositoryList()
    {
        _outposts.Add(new Outpost{Address = "Kolejowa 12, Warszawa",Id = Guid.NewGuid(), Name = "Rowerowy1"});
    }

    public void Delete(Guid guid)
    {
        var outpost = Get(guid);
        if (outpost != null)
            _outposts.Remove(outpost);
    }

    public List<Outpost> GetAll()
    {
        return _outposts.ToList();
    }

    public Outpost? Get(Guid guid)
    {
        return _outposts.FirstOrDefault(outpost => outpost.Id == guid);
    }

    public void Add(Outpost outpost)
    {
        var foundOutpost = Get(outpost.Id);
        if(foundOutpost == null)
            _outposts.Add(outpost);
    }

    public void Edit(Outpost outpost)
    {
        var foundOutpost = Get(outpost.Id);
        if (foundOutpost == null)
            return;
        foundOutpost.Address = outpost.Address;
        foundOutpost.Name = outpost.Name;
        foundOutpost.Workers = outpost.Workers;
    }

    public void EditWorkers(Outpost outpost)
    {
        var foundOutpost = Get(outpost.Id);
        if (foundOutpost == null)
            return;
        foundOutpost.Workers = outpost.Workers;
    }
}