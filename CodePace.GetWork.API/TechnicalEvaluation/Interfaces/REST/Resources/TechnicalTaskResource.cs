using CodePace.GetWork.API.TechnicalEvaluation.Domain.Model.ValueObjects;

namespace CodePace.GetWork.API.TechnicalEvaluation.Interfaces.REST.Resources;

public record TechnicalTaskResource(int Id, string Description, string Progress ,string Difficulty);