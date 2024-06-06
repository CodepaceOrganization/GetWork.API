using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;

namespace CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;

public partial class TechnicalTest
{
    public TechnicalTest(String title, String description, String imageUrl, ICollection<TechnicalTask> technicalTasks)
    {
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
        TechnicalTasks = technicalTasks;
    }

    public int Id { get; }
    public String Title { get; private set; }
    public String Description { get; private set; }
    public String ImageUrl { get; private set; }
    
}