namespace DefaultNamespace
{
    public class Time
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }
    }
}