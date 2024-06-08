using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.QueryServices;

public class CourseDetailQueryService(ICourseDetailRepository courseDetailRepository) : ICourseDetailQueryService
{
    public async Task<CourseDetail?> GetCourseDetailByCourseIdAsync(int courseId)
    {
        return await courseDetailRepository.FindByIdAsync(courseId);
    }

    public Task<IEnumerable<CourseDetail>> Handle(GetAllCourseDetailsByCourseIdQuery query)
    {
        throw new NotImplementedException();
    }
}