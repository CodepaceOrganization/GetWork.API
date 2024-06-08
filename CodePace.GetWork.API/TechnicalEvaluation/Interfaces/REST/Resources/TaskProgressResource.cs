namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

public record TaskProgressResource(int Id, int UserId, int TechnicalTaskId, TechnicalTaskResource TechnicalTask, string Progress);