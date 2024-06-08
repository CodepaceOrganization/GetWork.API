using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CourseDetailResourceFromEntityAssembler
{
    public static CourseDetailResource ToResourceFromEntity(CourseDetail entity)
    {
        return new CourseDetailResource(entity.Id, CourseResourceFromEntityAssembler.ToResourceFromEntity(entity.Course));
    }
}