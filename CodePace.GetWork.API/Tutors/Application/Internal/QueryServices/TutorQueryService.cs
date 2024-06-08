namespace DefaultNamespace;

public class TutorQueryService
{
    private readonly ITutorRepository _repository;

    public TutorQueryService(ITutorRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Tutor> GetTutors()
    {
        return _repository.GetAll();
    }

    public Tutor GetTutorById(int id)
    {
        return _repository.GetById(id);
    }
}
