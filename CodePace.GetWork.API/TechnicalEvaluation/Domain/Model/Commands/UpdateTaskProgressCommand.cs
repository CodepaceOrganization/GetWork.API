namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;

public record UpdateTaskProgressCommand(int TechnicalTestId, int UserId, int ProgressNumber);