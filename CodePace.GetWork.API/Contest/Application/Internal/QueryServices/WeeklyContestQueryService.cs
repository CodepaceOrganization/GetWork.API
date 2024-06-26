using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Model.Queries;
using CodePace.GetWork.API.contest.Domain.Repositories;
using CodePace.GetWork.API.contest.Domain.Services;
namespace CodePace.GetWork.API.contest.Application.Internal.QueryServices;

public class WeeklyContestQueryService(IWeeklyContestRepository weeklyContestRepository) : IWeeklyContestQueryService
{
    public async Task<IEnumerable<WeeklyContest>> Handle(GetAllWeeklyContestQuery query)
    {
        return await weeklyContestRepository.ListAsync();
    }
    
    public async Task<WeeklyContest?> Handle(GetWeeklyContestByIdQuery query)
    {
        return await weeklyContestRepository.FindByIdAsync(query.ContestId);
    }
}
