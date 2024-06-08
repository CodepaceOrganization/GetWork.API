using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Domain.Repositories;

namespace CodePace.GetWork.API.contest.Domain.Model.Aggregates
{
    public class Contest
    {
        public int Id { get; set; }
        public ICollection<WeeklyContest> WeeklyContests { get; set; }
        
        public Contest()
        {
            WeeklyContests = new List<WeeklyContest>();
        }
        
    }
}


    
   