using CodePace.GetWork.API.Tutors.Domain.Model.Commands;
using CodePace.GetWork.API.Tutors.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.Tutors.Interfaces.REST.Transform
{
    public static class CreateTutorsSourceCommandFromResourceAssembler
    {
        public static CreateTutorsCommand ToCommandFromSource(CreateTutorsResource resource)
        {
            return new CreateTutorsCommand(
                resource.Name,
                resource.Description,
                resource.Image,
                resource.Times
            );
        }
    }
}