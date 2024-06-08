namespace CodePace.GetWork.API.CourseContest.Domain.Model.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
    
    public CourseDetail CourseDetail { get; set; }
    
    public int CourseDeatilId { get; private set; }    
}