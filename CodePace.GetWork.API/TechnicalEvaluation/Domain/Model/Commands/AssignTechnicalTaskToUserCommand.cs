namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record AssignTechnicalTaskToUserCommand(int TechnicalTestId, int UserId);