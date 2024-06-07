namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record AssignTechnicalTaskToUserCommand(int UserId, int TechnicalTestId);