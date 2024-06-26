using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

public class TechnicalTask
{
    public int Id { get; }
    public string Description { get; private set; }
    public EDificultyStatus Difficulty { get; private set; }
    public TaskProgress TaskProgress { get; set; }
    public int TechnicalTestId { get; private set; } 
    public TechnicalTask(string description, EDificultyStatus difficulty, int technicalTestId)
    {
        Description = description;
        Difficulty = difficulty;
        TaskProgress = new TaskProgress(0,Id);
        this.TechnicalTestId = technicalTestId;
    }

    public TechnicalTask()
    {
        Description = string.Empty;
        Difficulty = EDificultyStatus.Easy;
        TaskProgress = new TaskProgress(0,Id);
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