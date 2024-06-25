using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public class UpdateGoalCommandFromResourceAssembler
{
    public static UpdateGoalCommand ToCommandFromResource(UpdateGoalResource resource)
    {
        return new UpdateGoalCommand(
            resource.Id,
            resource.Value);
    }
}