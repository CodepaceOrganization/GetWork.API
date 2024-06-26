using CodePace.GetWork.API.contest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.contest.Domain.Model.Commands;

public record CreateWeeklyContestCommand (string Title,string Urlimage, DateTime Date){ }