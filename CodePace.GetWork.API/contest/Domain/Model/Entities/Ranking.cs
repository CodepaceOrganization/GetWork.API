using CodePace.GetWork.API.contest.Domain.Model.Aggregates;

namespace CodePace.GetWork.API.contest.Domain.Model.Entities;

public class Ranking
{
    public int Id { get; set; }
    public int Rank { get; set; }
    public int UserId { get; set; }
    public int GlobalRankingId { get; set; }
}