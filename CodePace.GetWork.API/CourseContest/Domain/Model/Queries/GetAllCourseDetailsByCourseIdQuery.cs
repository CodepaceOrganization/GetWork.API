namespace CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

public class GetAllCourseDetailsByCourseIdQuery(int courseId)
{
    public int CourseId { get; } = courseId;
}