using CodePace.GetWork.API.contest.Domain.Model.Aggregates;
using CodePace.GetWork.API.contest.Domain.Model.Entities;
using CodePace.GetWork.API.contest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.contest.Interfaces.REST.Transform;

public class WeeklyContestResourceFromEntityAssembler
{
   public static WeeklyContestResource ToResourceFromEntity(WeeklyContest entity)
   {
      Console.WriteLine("WeeklyContest Name is " + entity.Title);
      return new WeeklyContestResource(entity.Id, entity.Title, entity.UrlImage, entity.Date);
   }
   
}