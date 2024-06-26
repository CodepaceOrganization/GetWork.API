using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Domain.Model.Queries;

namespace CodePace.GetWork.API.CourseContest.Domain.Services;

public interface IGoalQueryService
{
    Task<IEnumerable<Goal>>Handle(GetAllGoalQuery query);
    Task<Goal?>Handle(GetGoalByIdQuery query);
}