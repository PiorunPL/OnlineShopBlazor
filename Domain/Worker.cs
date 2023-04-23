namespace Domain;

public class Worker
{
    public Guid Id;
    public string FirstName;
    public string LastName;
    // public Outpost? Outpost; //TODO Zamiana na ID Outpostu
    public Guid OutpostId;
    
    public Worker(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        // Outpost = null;
        OutpostId = Guid.Empty;
    }
    
    public static Worker CreateNew(string firstName, string lastName)
    {
        return new Worker(Guid.NewGuid(), firstName, lastName);
    }
}