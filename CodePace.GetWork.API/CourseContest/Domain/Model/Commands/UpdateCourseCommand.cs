using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.CourseContest.Domain.Model.Commands;

public class UpdateCourseCommand
{
    public int Id { get; set; }
    public string Title { get; set; }
    public CourseDate Date { get; set; }
    public CourseImage Image { get; set; }
    public CourseDetail CourseDetail { get; set; }
    public Contest Contest { get; set; }

    public UpdateCourseCommand(int id, string title, CourseDate date, CourseImage image, CourseDetail courseDetail, Contest contest)
    {
        Id = id;
        Title = title;
        Date = date;
        Image = image;
        CourseDetail = courseDetail;
        Contest = contest;
    }
}