using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Repositories;

namespace CodePace.GetWork.API.contest.Domain.Model.Aggregates
{
    public class Contest
    {
        public int Id { get; private set; }
        public ICollection<WeeklyContest> WeeklyContests { get; set; }

        public Contest()
        {
            Id = 1;
            WeeklyContests = new List<WeeklyContest>();
        }
    }
}