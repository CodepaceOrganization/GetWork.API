using CodePace.GetWork.API.contest.Domain.Model.ValueObjects;
using System.Collections.Generic;
using CodePace.GetWork.API.contest.Domain.Model.Entities;

namespace CodePace.GetWork.API.contest.Domain.Model.Aggregates;

public  class GlobalRanking
{
    public int Id { get; set; }
    public Rating Rating { get; set; }
    public List<Ranking> Rankings { get; set; }
}