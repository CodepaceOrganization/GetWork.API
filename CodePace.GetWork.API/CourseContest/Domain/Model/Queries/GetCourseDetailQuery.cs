namespace CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

public class GetCourseDetailQuery(int courseId)
{
    public int CourseId { get; set; } = courseId;
}