using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Commands;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;

public static class CreateTechnicalTaskCommandFromResourceAssembler
{
    public static CreateTechnicalTaskCommand ToCommandFromResource(CreateTechnicalTaskResource resource)
    {
        return new CreateTechnicalTaskCommand(resource.Description, resource.Difficulty);
    }
}