using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CreateGoalCommandFromResourceAssembler
{
    public static CreateGoalCommand ToCommandFromResource(CreateGoalResource resource)
    {
        return new CreateGoalCommand(
            resource.CourseDetailId,
            resource.Value
        );
    }
}