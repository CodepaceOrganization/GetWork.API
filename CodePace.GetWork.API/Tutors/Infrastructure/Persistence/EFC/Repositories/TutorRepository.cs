namespace DefaultNamespace;

public class TutorRepository: ITutorRepository
{
        private readonly List<Tutor> _tutors = new List<Tutor>
        {
            new Tutor
            {
                Id = 4,
                Name = "Fred F. Jones",
                Description = "Tutora especializada en ciencia de datos y análisis de datos, con un enfoque en lenguajes como R y Python. Sus clases se centran en aplicaciones prácticas y casos de uso del mundo real, brindando a los estudiantes las habilidades necesarias para trabajar en proyectos de análisis de datos.",
                Image = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRRMac9mqjIX-epY7BXzI0LiP0C8JwzRKVfmSbRsm6J0PapspvX",
                Times = new List<string> { "11:00 AM", "1:00 PM", "4:00 PM", "6:00 PM" }
            }
        };

        public IEnumerable<Tutor> GetAll()
        {
            return _tutors;
        }

        public Tutor GetById(int id)
        {
            return _tutors.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Tutor tutor)
        {
            tutor.Id = _tutors.Max(t => t.Id) + 1; // Generate new ID
            _tutors.Add(tutor);
        }
    }
