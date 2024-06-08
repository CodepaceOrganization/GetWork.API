namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record CreateTechnicalTaskCommand(int TechnicalTestId, string Description, string Difficulty);