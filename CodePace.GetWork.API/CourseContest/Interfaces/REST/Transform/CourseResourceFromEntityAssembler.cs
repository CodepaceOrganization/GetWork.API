using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CourseResourceFromEntityAssembler
{
    public static CourseResource ToResourceFromEntity(Course entity)
    {
        return new CourseResource(entity.Id, entity.Title, entity.Date, entity.Image);
    }
}