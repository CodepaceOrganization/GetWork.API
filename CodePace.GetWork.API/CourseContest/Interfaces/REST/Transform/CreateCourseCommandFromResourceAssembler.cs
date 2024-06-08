using CodePace.GetWork.API.CourseContest.Domain.Model.Commands;
using CodePace.GetWork.API.CourseContest.Domain.Model.ValueObjects;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CreateCourseCommandFromResourceAssembler
{
    public static CreateCourseCommand ToCommandFromResource(CreateCourseResource resource)
    {
        return new CreateCourseCommand(resource.Title, new CourseDate(resource.Date), new CourseImage(resource.Image), null, null);
    }
}