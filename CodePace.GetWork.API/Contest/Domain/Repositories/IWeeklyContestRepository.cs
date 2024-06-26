using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.Shared.Domain.Repositories;

namespace CodePace.GetWork.API.contest.Domain.Repositories;

public interface IWeeklyContestRepository : IBaseRepository<WeeklyContest>
{
}