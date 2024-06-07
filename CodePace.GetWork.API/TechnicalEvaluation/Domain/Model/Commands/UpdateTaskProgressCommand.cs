namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record UpdateTaskProgressCommand(int TechnicalTaskId, int UserId, string Progress);