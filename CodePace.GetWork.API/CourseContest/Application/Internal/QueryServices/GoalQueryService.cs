using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;
using CodePace.GetWork.API.CourseContest.Domain.Repositories;
using CodePace.GetWork.API.CourseContest.Domain.Services;

namespace CodePace.GetWork.API.CourseContest.Application.Internal.QueryServices;



public class GoalQueryService(IGoalRepository courseDetailRepository): IGoalQueryService
{
    public async Task<IEnumerable<Goal>> Handle(GetAllGoalQuery query)
    {
        return await courseDetailRepository.ListAsync();
    }
    
    public async Task<Goal?> Handle(GetGoalByIdQuery query)
    {
        return await courseDetailRepository.FindByIdAsync(query.CourseDetailId);
    }
}