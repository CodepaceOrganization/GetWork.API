using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface IDetailQueryService
{
    Task<IEnumerable<CourseDetail>>Handle(GetAllCourseDetailQuery query);
    Task<CourseDetail?>Handle(GetCourseDetailByIdQuery query);
}