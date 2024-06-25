using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public class UpdateCourseDetailCommandFromResourceAssembler
{
    public static UpdateCourseDetailCommand ToCommandFromResource(UpdateCourseDetailResource resource)
    {
        return new UpdateCourseDetailCommand(
            resource.Id, 
            resource.Description, 
            resource.Image,
            resource.Image2,
            resource.Image3, 
            resource.Introduction,
            resource.Development, 
            resource.Test);
}
}