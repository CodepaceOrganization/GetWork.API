namespace CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;

public class CourseImage
{
    public string ImageUrl { get; set; }

    public CourseImage(string imageUrl)
    {
        ImageUrl = imageUrl;
    }
}