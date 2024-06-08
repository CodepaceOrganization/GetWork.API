namespace DefaultNamespace;

public record TutorResource(int Id, string Name, string Description, string Image, List<string> Times)
{
    public static TutorResource ToResourceFromEntity(Tutor tutor)
    {
        return new TutorResource(tutor.Id, tutor.Name, tutor.Description, tutor.Image, tutor.Times.Select(t => t.Value).ToList());
    }
}