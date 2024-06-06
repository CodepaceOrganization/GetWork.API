namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record UpdateTaskProgressCommand(int TechicalTaskId, int UserId, String Progress);