using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Model.Queries;

namespace CodePace.GetWork.API.contest.Domain.Services;

public interface IContestQueryService
{ 
    Task<IEnumerable<WeeklyContest>>Handle(GetAllWeeklyContestQuery query);
    Task<WeeklyContest?>Handle(GetWeeklyContestByIdQuery query);
}