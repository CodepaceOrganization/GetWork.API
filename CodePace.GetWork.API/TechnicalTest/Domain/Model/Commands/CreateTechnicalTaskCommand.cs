namespace CodePace.GetWork.API.TechnicalTest.Domain.Model.Commands;

public record CreateTechnicalTaskCommand(int UserId, string TaskName, string Description, string Difficulty);