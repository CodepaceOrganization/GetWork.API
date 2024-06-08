using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.Aggregates;
using CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Transform;

public static class TechnicalTestResourceFromEntityAssembler
{
    public static TechnicalTestResource ToResourceFromEntity(TechnicalTest technicalTest)
    {
        return new TechnicalTestResource(
            technicalTest.Id,
            technicalTest.Title,
            technicalTest.Description,
            technicalTest.ImageUrl
        );
    }
}