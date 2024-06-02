using CodePace.GetWork.API.TechnicalTest.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalTest.Domain.Model.Entities;

public class TechnicalTask
{
    public UserId UserId { get; private set; }
    public string TaskName { get; private set; }
    public string Description { get; private set; }
    public EDificultyStatus Difficulty { get; private set; }
    public Progress Progress { get; private set; }

    public TechnicalTask(UserId userId, string taskName, string description, EDificultyStatus difficulty, Progress progress)
    {
        UserId = userId;
        TaskName = taskName;
        Description = description;
        Difficulty = difficulty;
        Progress = progress;
    }

    public void UpdateTaskName(string taskName)
    {
        TaskName = taskName;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdateDifficulty(EDificultyStatus difficulty)
    {
        Difficulty = difficulty;
    }

    public void UpdateProgress(Progress progress)
    {
        Progress = progress;
    }
}