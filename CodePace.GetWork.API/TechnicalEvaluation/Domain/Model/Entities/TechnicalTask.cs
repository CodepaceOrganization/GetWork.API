using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

public class TechnicalTask
{
    public int Id { get; }
    public string Description { get; private set; }
    public EDificultyStatus Difficulty { get; private set; }
    public int TechnicalTestId { get; private set; } 
    public TechnicalTask(UserId userId, string description, EDificultyStatus difficulty)
    {
        Description = description;
        Difficulty = difficulty;
    }

    public TechnicalTask()
    {
        Description = string.Empty;
        Difficulty = EDificultyStatus.Easy;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdateDifficulty(EDificultyStatus difficulty)
    {
        Difficulty = difficulty;
    }

}