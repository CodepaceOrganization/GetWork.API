using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.QueryServices;

public class CourseQueryService(ICourseRepository courseRepository) : ICourseQueryService
{
    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await courseRepository.ListAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await courseRepository.FindByIdAsync(id);
    }

    public Task<Course> Handle(GetCourseByIdQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> Handle(GetAllCoursesQuery query)
    {
        throw new NotImplementedException();
    }
}