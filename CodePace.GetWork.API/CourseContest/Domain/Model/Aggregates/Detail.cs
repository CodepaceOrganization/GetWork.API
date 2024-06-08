using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;

public class Detail
{
    public int Id { get; set; }
    public string Title { get; set; }
    public CourseDate Date { get; set; }
    public CourseImage Image { get; set; }
    public CourseDetail CourseDetail { get; set; }
    public Contest Contest { get; set; }

    public Detail(int id, string title, CourseDate date, CourseImage image, CourseDetail courseDetail, Contest contest)
    {
        Id = id;
        Title = title;
        Date = date;
        Image = image;
        CourseDetail = courseDetail;
        Contest = contest;
    }

    // Additional methods for aggregate behavior
}