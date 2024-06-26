using CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates;
using CodePace.GetWork.API.CourseContest.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.CourseContest.Interfaces.REST.Transform;

public static class CourseDetailResourceFromEntityAssembler
{
    public static CourseDetailResource ToResourceFromEntity(CourseDetail entity)
    {
        return new CourseDetailResource(
            entity.Id,
            entity.Description,
            entity.Image,
            entity.Image2,
            entity.Image3,
            entity.Introduction,
            entity.Development,
            entity.Test
            );
    }
}