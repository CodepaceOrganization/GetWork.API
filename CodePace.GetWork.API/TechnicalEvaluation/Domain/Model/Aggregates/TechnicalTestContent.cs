using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;

public partial class TechnicalTest
{
    public TechnicalTest()
    {
        Title = string.Empty;
        Description = string.Empty;
        ImageUrl = string.Empty;
        TestType = string.Empty;
        TechnicalTasks = new List<TechnicalTask>();
    }
    
    public ICollection<TechnicalTask> TechnicalTasks { get; private set; }
    public String TestType { get; private set; }
    public void AssignTechnicalTask(TechnicalTask technicalTask)
    {
        TechnicalTasks.Add(technicalTask);
    }
}