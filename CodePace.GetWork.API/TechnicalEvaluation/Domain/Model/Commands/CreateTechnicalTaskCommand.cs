namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record CreateTechnicalTaskCommand(int UserId, string Description, string Difficulty);