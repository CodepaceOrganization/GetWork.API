using CodePace.GetWork.API.contest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.contest.Domain.Model.Commands;

public record CreateWeeklyContestCommand (int ContestId,string Title,string Urlimage, DateTime Date){ }