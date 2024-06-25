using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public class GoalResourceFromEntityAssembler
{
public static GoalResource ToResourceFromEntity(Goal entity)
    {
        return new GoalResource(
            entity.Id,
            entity.Value
            );
    }
}