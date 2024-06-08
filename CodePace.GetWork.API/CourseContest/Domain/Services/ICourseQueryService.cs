using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface ICourseQueryService
{
    Task<Course> Handle(GetCourseByIdQuery query);
    Task<IEnumerable<Course>> Handle(GetAllCoursesQuery query);
    // Other methods...
}