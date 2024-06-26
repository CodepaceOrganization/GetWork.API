using CodePace.GetWork.API.contest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.contest.Interfaces.REST.Resources;

public record CreateWeeklyContestResource(string Title,string UrlImage, DateTime Date);