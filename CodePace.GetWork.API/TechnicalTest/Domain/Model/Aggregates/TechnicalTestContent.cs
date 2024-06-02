using CodePace.GetWork.API.TechnicalTest.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalTest.Domain.Model.Aggregates;

public partial class TechnicalTest
{
    public TechnicalTest()
    {
        Title = string.Empty;
        Description = string.Empty;
        ImageUrl = string.Empty;
        TechnicalTasks = new List<TechnicalTask>();
    }
    
    public ICollection<TechnicalTask> TechnicalTasks { get; private set; }
}