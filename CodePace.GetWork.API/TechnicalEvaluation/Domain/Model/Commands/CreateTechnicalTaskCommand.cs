namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record CreateTechnicalTaskCommand(int UserId, string TaskName, string Description, string Difficulty);