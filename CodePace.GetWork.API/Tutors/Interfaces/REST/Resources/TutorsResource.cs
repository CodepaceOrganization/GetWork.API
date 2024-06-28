namespace CodePace.GetWork.API.Tutors.Interfaces.REST.Resources
{
    public record TutorsResource(int Id, string Name, string Description, string Image, List<string> Times);
}