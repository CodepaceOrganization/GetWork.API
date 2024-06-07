namespace DefaultNamespace;

public class TutorCommandService
{
    private readonly ITutorRepository _repository;

    public TutorCommandService(ITutorRepository repository)
    {
        _repository = repository;
    }

    public void AddTutor(Tutor tutor)
    {
        _repository.Add(tutor);
    }

    public void Handle(CreateTutorCommand command)
    {
        var tutor = new Tutor
        {
            Name = command.Name,
            Description = command.Description,
            Image = command.Image,
            Times = command.Times
        };

        AddTutor(tutor);
    }
}