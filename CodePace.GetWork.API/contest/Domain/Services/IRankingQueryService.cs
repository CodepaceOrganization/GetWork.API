using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Queries;

namespace CodePace.GetWork.API.contest.Domain.Services;

public interface IRankingQueryService
{
    Task<GlobalRanking?>Handle(GetAllRankingQuery query);
    Task<GlobalRanking?>Handle(GetRankingByIdQuery query);
}