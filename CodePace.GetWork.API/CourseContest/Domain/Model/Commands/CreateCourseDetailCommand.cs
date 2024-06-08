using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

namespace CodePace.GetWork.API.CourseContest.Domain.Model.Commands;

public class CreateCourseDetailCommand
{
    public int CourseId { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string Introduction { get; set; }
    public string Development { get; set; }
    public string Test { get; set; }
    public List<string> Goals { get; set; }

    public CreateCourseDetailCommand(int courseId, string description, string image, string image2, string image3, string introduction, string development, string test, List<string> goals)
    {
        CourseId = courseId;
        Description = description;
        Image = image;
        Image2 = image2;
        Image3 = image3;
        Introduction = introduction;
        Development = development;
        Test = test;
        Goals = goals;
    }
    
}