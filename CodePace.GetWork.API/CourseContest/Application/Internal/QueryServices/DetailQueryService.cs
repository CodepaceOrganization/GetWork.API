using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.QueryServices;

public class DetailQueryService(ICourseDetailRepository courseDetailRepository): IDetailQueryService
{
    public async Task<IEnumerable<CourseDetail>> Handle(GetAllCourseDetailQuery query)
    {
        return await courseDetailRepository.ListAsync();
    }
    
    public async Task<CourseDetail?> Handle(GetCourseDetailByIdQuery query)
    {
        return await courseDetailRepository.FindByIdAsync(query.ContestId);
    }
}