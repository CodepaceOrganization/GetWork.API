using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Commands;

namespace CodePace.GetWork.API.contest.Domain.Services;

public interface IRankingCommandService
{
    public Task<GlobalRanking?> Handle(UpdateGlobalRankingCommand command);
}