namespace CodePace.GetWork.API.TechnicalTest.Domain.Model.Aggregates;

public partial class TechnicalTest
{
    public TechnicalTest(String title, String description, String imageUrl)
    {
        Title = title;
        Description = description;
        ImageUrl = imageUrl;
    }
    
    public String Title { get; private set; }
    public String Description { get; private set; }
    public String ImageUrl { get; private set; }
    
}