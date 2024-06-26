using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Commands;
using CodePace.GetWork.API.contest.Domain.Model.Entities;

namespace CodePace.GetWork.API.contest.Domain.Services;

public interface IWeeklyContestCommandService
{
    public Task<WeeklyContest?> Handle(CreateWeeklyContestCommand command);
    public Task<WeeklyContest?> Handle(UpdateWeeklyContestCommand command);
    
}