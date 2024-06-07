using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Entities;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;

public static class TechnicalTaskResourceFromEntityAssembler
{
    public static TechnicalTaskResource ToResourceFromEntity(TechnicalTask entity)
    {
        return new TechnicalTaskResource(entity.Id, entity.Description, entity.Difficulty);
        
    }
}