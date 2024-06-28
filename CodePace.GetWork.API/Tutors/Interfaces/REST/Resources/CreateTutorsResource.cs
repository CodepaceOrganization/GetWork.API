namespace CodePace.GetWork.API.Tutors.Interfaces.REST.Resources
{
    public record CreateTutorsResource(string Name, string Description, string Image, List<string> Times);
}