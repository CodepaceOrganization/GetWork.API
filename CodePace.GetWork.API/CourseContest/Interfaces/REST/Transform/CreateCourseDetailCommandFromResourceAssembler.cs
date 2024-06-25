using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CreateCourseDetailCommandFromResourceAssembler
{
    public static CreateCourseDetailCommand ToCommandFromResource(CreateCourseDetailResource resource)
    {
        return new CreateCourseDetailCommand(
            resource.ContestId,
            resource.Description,
            resource.Image,
            resource.Image2,
            resource.Image3,
            resource.Introduction,
            resource.Development,
            resource.Test
        );
    }
}