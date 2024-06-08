namespace CodePace.GetWork.API.contest.Domain.Model.Commands;

public record UpdateWeeklyContestCommand(int Id,string Title,string UrlImage, DateTime Date){}