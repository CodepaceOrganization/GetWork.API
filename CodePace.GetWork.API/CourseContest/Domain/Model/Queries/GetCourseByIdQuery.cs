namespace CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

public class GetCourseByIdQuery(int id)
{
    public int Id { get; } = id;
}