namespace CodePace.GetWork.API.Tutors.Domain.Model.Commands
{
    public record CreateTutorsCommand(string Name, string Description, string Image, List<string> Times);
}