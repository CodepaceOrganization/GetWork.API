using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

public class TechnicalTask
{
    public int Id { get; }
    public UserId UserId { get; private set; }
    public string Description { get; private set; }
    public EDificultyStatus Difficulty { get; private set; }
    public EProgress Progress { get; private set; }

    public TechnicalTask(UserId userId, string description, EDificultyStatus difficulty, EProgress progress)
    {
        UserId = userId;
        Description = description;
        Difficulty = difficulty;
        Progress = progress;
    }

    public TechnicalTask()
    {
        UserId = new UserId(0);
        Description = string.Empty;
        Difficulty = EDificultyStatus.Easy;
        Progress = EProgress.Earrings;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdateDifficulty(EDificultyStatus difficulty)
    {
        Difficulty = difficulty;
    }

    public void UpdateProgress(EProgress progress)
    {
        Progress = progress;
    }
}