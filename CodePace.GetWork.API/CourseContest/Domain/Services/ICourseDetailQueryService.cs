using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface ICourseDetailQueryService
{
    Task<IEnumerable<CourseDetail>> Handle(GetAllCourseDetailsByCourseIdQuery query);
    // Other methods...
}