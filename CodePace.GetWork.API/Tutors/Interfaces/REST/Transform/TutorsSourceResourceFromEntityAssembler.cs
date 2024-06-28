using CodePace.GetWork.API.Tutors.Domain.Model.Entities;
using CodePace.GetWork.API.Tutors.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.Tutors.Interfaces.REST.Transform
{
    public static class TutorsSourceResourceFromEntityAssembler
    {
        public static TutorsResource ToResourceFromEntity(Tutor entity)
        {
            return new TutorsResource(
                entity.Id,
                entity.Name,
                entity.Description,
                entity.Image,
                entity.Times
            );
        }
    }
}