using CodePace.GetWork.API.contest.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.contest.Domain.Model.Commands;

public record UpdateGlobalRankingCommand (int Id,string UserName,string Urlimage, Rating Rating){ }