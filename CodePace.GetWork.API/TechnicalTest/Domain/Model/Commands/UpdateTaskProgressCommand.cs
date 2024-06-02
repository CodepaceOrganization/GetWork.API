namespace CodePace.GetWork.API.TechnicalTest.Domain.Model.Commands;

public record UpdateTaskProgressCommand(int TechnicalTestId, int UserId, int ProgressNumber);