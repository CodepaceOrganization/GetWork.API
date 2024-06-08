namespace DefaultNamespace;

public interface ITutorRepository
{
        IEnumerable<Tutor> GetAll();
        Tutor GetById(int id);
        void Add(Tutor tutor);
}