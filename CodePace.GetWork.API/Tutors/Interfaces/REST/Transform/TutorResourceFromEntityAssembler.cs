namespace DefaultNamespace
{
    public static class TutorResourceFromEntityAssembler
    {
        public static TutorResource ToResourceFromEntity(Tutor tutor)
        {
            return new TutorResource(tutor.Id, tutor.Name, tutor.Description, tutor.Image, tutor.Times.Select(t => t.Value).ToList());
        }
    }
}