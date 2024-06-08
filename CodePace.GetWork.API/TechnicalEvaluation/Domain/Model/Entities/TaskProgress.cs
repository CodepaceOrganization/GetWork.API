using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

public class TaskProgress
{
    public int UserId { get; set; }

    public int TechnicalTaskId { get; set; }
    public TechnicalTask TechnicalTask { get; set; }

    public EProgress Progress { get; set; }
    
    public TaskProgress()
    {
        UserId = 0;
        Progress = EProgress.Earrings;
    }
    public TaskProgress(int userId,int technicalTaskId)
    {
        UserId = userId;
        TechnicalTaskId = technicalTaskId;
        Progress = EProgress.Earrings;
    }
    public void UpdateUserId(int userId)
    {
        UserId = userId;
    }
    public void UpdateProgress(EProgress progress)
    {
        Progress = progress;
    }
}